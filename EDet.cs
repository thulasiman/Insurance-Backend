using InsurencePolicy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsurencePolicy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EDet : ControllerBase
    {

        private readonly InsurancePolicyContext _context;

        public EDet(InsurancePolicyContext context) => _context = context;

        [HttpGet]

        public async Task<IEnumerable<EDetail>> GetUsers()
        {
            return await _context.EDetails.ToListAsync();
        }

    }
}
