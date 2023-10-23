using PreParcial.DAL.Entities;

namespace PreParcial.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId); //Firma del metodo
        Task<State> CreateStateAsync(State state,Guid countryId);
        Task<State> GetStateByIdAsync(Guid id); //Para traerlo por id
      
       Task<State> EditStateAsync(State state,Guid id); //Editar 

        Task<State> DeleteStateAsync(Guid id);//Delete
    }
}
