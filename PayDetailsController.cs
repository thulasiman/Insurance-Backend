using Microsoft.AspNetCore.Mvc;
using InsurencePolicy.Model;
using Microsoft.EntityFrameworkCore;

namespace InsurencePolicy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayDetailsController : Controller
    {
        private readonly InsurancePolicyContext _context;

        public PayDetailsController(InsurancePolicyContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<IEnumerable<PayDetail>> GetUsers()
        {
            return await _context.PayDetails.ToListAsync();
        }

        [HttpPost]

        public async Task<IActionResult> createPayDeatils([FromBody] PayDetail payDetail)
        {
            _context.Add(payDetail);
            await _context.SaveChangesAsync();
            return Ok(payDetail);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var dbUser = await _context.PayDetails.FindAsync(id);

            if (dbUser == null)
            {
                return NotFound(); // Or appropriate action if user with given id is not found
            }

            _context.PayDetails.Remove(dbUser); // Corrected from _context..Remove(dbUser);

            await _context.SaveChangesAsync();

            return Ok("Successfully deleted!");
        }
    }
}
