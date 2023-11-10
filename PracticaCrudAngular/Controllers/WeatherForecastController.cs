using Microsoft.AspNetCore.Mvc;
using PracticaCrud.AplicacionWeb.Models;
using PracticaCrud.AplicacionWeb.Models.ViewModels;
using PracticaCrud.BLL.Service;
using PracticaCrud.Models;

namespace PracticaCrudAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IArticuloService _ArticuloService;

        public WeatherForecastController(IArticuloService articuloService)
        {
            _ArticuloService = articuloService;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Artículo> queryArticuloSQL = await _ArticuloService.GetAll();

            List<VMArticulo> listArticulos = queryArticuloSQL.Select(a => new VMArticulo()
            {
                Código = a.Código,
                Descripción = a.Descripción,
                Precio = a.Precio,
                Imagen = a.Imagen,
                Stock = a.Stock
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, listArticulos);
        }
    }
}