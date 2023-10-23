using Microsoft.EntityFrameworkCore;
using PreParcial.DAL;
using PreParcial.DAL.Entities;
using PreParcial.Domain.Interfaces;

namespace PreParcial.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            return await _context.States.Where(s => s.CountryId== countryId)
                .ToListAsync();
          
        }


        public async Task<State> CreateStateAsync(State state, Guid countryId)
        {
            try
            {
                state.Id = Guid.NewGuid(); //Así se asigna automáticamente un ID a un nuevo registro
                state.CreatedDate = DateTime.Now;
                state.CountryId = countryId;
                state.Country = await _context.Countries.FirstOrDefaultAsync(c=> c.Id== countryId);
                state.ModifiedDate = null;

                _context.Countries.Add(state); //Aquí estoy creando el objeto Country en el contexto de mi BD
                await _context.SaveChangesAsync(); //Aquí ya estoy yendo a la BD para hacer el INSERT en la tabla Countries

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                //Esta exceptión me captura un mensaje cuando el país YA EXISTE (Duplicados)
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences Notation --> ??
            }
        }

        public async Task<Country> GetStateyByIdAsync(Guid id)
        {
            //return await _context.Countries.FindAsync(id); // FindAsync es un método propio del DbContext (DbSet)
            //return await _context.Countries.FirstAsync(x => x.Id == id); //FirstAsync es un método de EF CORE
            return await _context.States.FirstOrDefaultAsync(s => s.Id == id); //FirstOrDefaultAsync es un método de EF CORE
        }


        public async Task<State> EditStateAsync(State state, Guid id)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;

                _context.States.Update(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                if (state == null) return null;

                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}  

