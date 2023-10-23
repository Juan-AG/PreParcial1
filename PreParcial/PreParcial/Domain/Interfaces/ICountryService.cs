using PreParcial.DAL.Entities;

namespace PreParcial.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); //Firma del metodo
        Task<Country> CreateCountryAsync(Country country);
    }
}
