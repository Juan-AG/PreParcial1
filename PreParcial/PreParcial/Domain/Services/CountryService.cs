using Microsoft.EntityFrameworkCore;
using PreParcial.DAL;
using PreParcial.DAL.Entities;
using PreParcial.Domain.Interfaces;

namespace PreParcial.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries; //Aquí lo que hago es traerme todos los datos que tengo en mi tabla Countries.
        }
    }
}
