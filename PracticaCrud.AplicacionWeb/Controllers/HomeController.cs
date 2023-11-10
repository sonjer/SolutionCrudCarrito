using Microsoft.AspNetCore.Mvc;
using PracticaCrud.AplicacionWeb.Models;
using PracticaCrud.AplicacionWeb.Models.ViewModels;
using PracticaCrud.BLL.Service;
using PracticaCrud.Models;
using System.Diagnostics;

namespace PracticaCrud.AplicacionWeb.Controllers
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
        [Route("api/ListaArticulos")]
        public async Task<IActionResult> ListaArticulos()
        {
            IQueryable<Artículo> queryArticuloSQL = await _ArticuloService.GetAll();

            List<VMArticulo> listArticulos = queryArticuloSQL.Select(a => new VMArticulo()
            {
                Codigo = a.Codigo,
                Descripcion = a.Descripcion,
                Precio = a.Precio,
                Imagen = a.Imagen,
                Stock = a.Stock
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, listArticulos);
        }

        [HttpPost]
        [Route("api/insertArticulo")]
        public async Task<IActionResult> InsertarArticulo([FromBody] VMArticulo articulo)
        {

            Artículo nuevoArticulo = new Artículo();
            {
                nuevoArticulo.Descripcion = articulo.Descripcion;
                nuevoArticulo.Precio = articulo.Precio;
                nuevoArticulo.Imagen = articulo.Imagen;
                nuevoArticulo.Stock = articulo.Stock;

            };

            bool respuesta = await _ArticuloService.Insert(nuevoArticulo);

            return StatusCode(StatusCodes.Status200OK, new {valor = respuesta});
        }

        [HttpPut]
        [Route("api/updateArticulo")]
        public async Task<IActionResult> updateArticulo([FromBody] VMArticulo articulo)
        {

            Artículo articuloActualizar = new Artículo();
            {
                articuloActualizar.Codigo = articulo.Codigo;
                articuloActualizar.Descripcion = articulo.Descripcion;
                articuloActualizar.Precio = articulo.Precio;
                articuloActualizar.Imagen = articulo.Imagen;
                articuloActualizar.Stock = articulo.Stock;

            };

            bool respuesta = await _ArticuloService.Update(articuloActualizar);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPost]
        [Route("api/deleteArticulo")]
        public async Task<IActionResult> deleteArticulo([FromBody] int id)
        {
            bool respuesta = await _ArticuloService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
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