using InsurencePolicy.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionstring = builder.Configuration.GetConnectionString("OInsurenceDB");
builder.Services.AddDbContextPool<InsurancePolicyContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options.WithOrigins("http://localhost:4200")

                            .AllowAnyMethod()

                            .AllowAnyHeader()

                            .SetIsOriginAllowed(origin => true)

                            .AllowCredentials());

app.Run();
