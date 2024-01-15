using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Entities;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly CountriesDbContext _dbContext;

        public CountriesController(ILogger<CountriesController> logger, CountriesDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries = await _dbContext.Countries
                .Include(c => c.Cities)
                .ToListAsync();

            return Ok(countries);
        }
    }
}