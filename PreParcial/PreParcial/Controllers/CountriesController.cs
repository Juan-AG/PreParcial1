using Microsoft.AspNetCore.Mvc;
using PreParcial.DAL.Entities;
using PreParcial.Domain.Interfaces;

namespace PreParcial.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        //En un controlador los métodos cambian de nombre, y realmente se llaman ACCIONES (ACTIONS) - Si es una API, se denomina ENDPOINT.
        //Todo Endpoint retorna un ActionResult, significa que retorna el resultado de una ACCIÓN.

        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync(); //Aquí estoy yendo a mi capa de Domain para traerme la lista de países

            //El método Any() significa si hay al menos un elemento.
            //El Método !Any() significa si no hay absoluta/ nada.
            if (countries == null || !countries.Any())
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(countries); //Ok = 200 Http Status Code
        }
    }
}
