using PreParcial.DAL.Entities;

namespace PreParcial.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); //Firma del metodo
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(Guid id); //Para traerlo por id
        Task<Country> GetCountryByNameAsync(string name);//Por nombre

     
       Task<Country> EditCountryAsync(Country c); //Editar 

        Task<Country> DeleteCountryAsync(Guid id);//Delete
    }
}
