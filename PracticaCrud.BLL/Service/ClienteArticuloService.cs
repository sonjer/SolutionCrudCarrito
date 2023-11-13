using PracticaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCrud.DAL.Repositorio;


namespace PracticaCrud.BLL.Service
{
    public class ClienteArticuloService : IClienteArticulosService

    {
        private readonly IGenericRepository<ClienteArticulo> _clienteArticuloRepo;
        public ClienteArticuloService(IGenericRepository<ClienteArticulo> clienteArticuloRepo)
        {
            _clienteArticuloRepo = clienteArticuloRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _clienteArticuloRepo.Delete(id);
        }

        public async Task<ClienteArticulo> Get(int id)
        {
            return await _clienteArticuloRepo.Get(id);
        }

        public async Task<IQueryable<ClienteArticulo>> GetAll()
        {
            return await _clienteArticuloRepo.GetAll();
        }

        public async Task<bool> Insert(ClienteArticulo modelo)
        {
            return await _clienteArticuloRepo.Insert(modelo);
        }

        public async Task<bool> Update(ClienteArticulo modelo)
        {
            return await _clienteArticuloRepo.Update(modelo);
        }
    }
}
