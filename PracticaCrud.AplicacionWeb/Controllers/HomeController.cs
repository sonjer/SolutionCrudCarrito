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
        private readonly IClienteArticulosService _ClienteArticulosService;


        public HomeController(IArticuloService articuloService, IClienteArticulosService clienteArticulosService)
        {
            _ArticuloService = articuloService;
            _ClienteArticulosService = clienteArticulosService;

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

        [HttpGet]
        [Route("api/ListaClientesArticulos")]
        public async Task<IActionResult> ListaClientesArticulos()
        {
            IQueryable<ClienteArticulo> queryArticuloSQL = await _ClienteArticulosService.GetAll();

            List<ClienteArticulo> listClienteArticulos = queryArticuloSQL.Select(c => new ClienteArticulo()
            {
               Id = c.Id,
               ClienteId = c.ClienteId,
               ArticuloId = c.ArticuloId,
               CantidadArticulos = c.CantidadArticulos,
               Fecha = c.Fecha,
               Articulo = c.Articulo,
               Cliente = c.Cliente
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, listClienteArticulos);
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