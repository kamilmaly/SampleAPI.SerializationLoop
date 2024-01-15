using Microsoft.EntityFrameworkCore;
using SampleAPI.Entities;
using System.Data;
using System.Net;

namespace SampleAPI.Net6
{
    public class SampleSeeder
    {
        private readonly CountriesDbContext _dbContext;
        public SampleSeeder(CountriesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Countries.Any())
                {
                    var countries = GetCountries();
                    _dbContext.Countries.AddRange(countries);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Cities.Any())
                {
                    var cities = GetCities();
                    _dbContext.Cities.AddRange(cities);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Country> GetCountries()
        {
            var countries = new List<Country>()
            {
                new Country()
                {
                    Name = "Poland"
                },
                new Country()
                {
                    Name = "Germany"
                },
                new Country()
                {
                    Name = "Spain"
                }
            };

            return countries;
        }

        private IEnumerable<City> GetCities()
        {
            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Warsaw",
                    CountryId = 1

                },
                new City()
                {
                    Name = "Berlin",
                    CountryId = 2

                },
                new City()
                {
                    Name = "Madryt",
                    CountryId = 3

                }
            };

            return cities;
        }
    
}
}
