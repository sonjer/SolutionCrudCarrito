using Microsoft.AspNetCore.Mvc;
using PracticaCrud.AplicacionWeb.Models;
using PracticaCrud.AplicacionWeb.Models.ViewModels;
using PracticaCrud.BLL.Service;
using PracticaCrud.Models;
using System.Diagnostics;

namespace PracticaCrud.AplicacionWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IClienteService _clienteService;

        public AuthController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/ListaClientes")]
        public async Task<IActionResult> ListaClientes()
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteService.GetAll();

            List<VMCliente> listClientes = queryClienteSQL.Select(a => new VMCliente()
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellidos = a.Apellidos,
                Email = a.Email,
                Password = a.Password
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, listClientes);
        }

        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] Cliente usuario)
        {
            var user = _clienteService.FindByEmailAndPassword(usuario.Email, usuario.Password);
            if (user == null)
            {
                return Unauthorized(); // No autorizado
            }

            // Genera un token JWT y envíalo al cliente
            var cliente = user;
            return StatusCode(StatusCodes.Status200OK, cliente);
        }
    }
}
