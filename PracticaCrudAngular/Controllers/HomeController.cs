using Microsoft.AspNetCore.Mvc;
using PracticaCrud.AplicacionWeb.Models;
using PracticaCrud.AplicacionWeb.Models.ViewModels;
using PracticaCrud.BLL.Service;
using PracticaCrud.Models;
using System.Diagnostics;

namespace PracticaCrudAngular.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticuloService _ArticuloService;

        public HomeController(IArticuloService articuloService)
        {
            _ArticuloService = articuloService;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}