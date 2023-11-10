using PracticaCrud.DAL.Repositorio;
using PracticaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCrud.BLL.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepo;
        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _clienteRepo.Delete(id);
        }

        public async Task<Cliente> Get(int id)
        {
            return await _clienteRepo.Get(id);
        }

        public async Task<IQueryable<Cliente>> GetAll()
        {
            return await _clienteRepo.GetAll();
        }

        public async Task<Cliente> FindByEmailAndPassword(string email, string password)
        {
            IQueryable<Cliente> queryClienteSQL = await _clienteRepo.GetAll();
            Cliente cliente = queryClienteSQL.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
            return cliente;
        }

        public async Task<bool> Insert(Cliente modelo)
        {
            return await _clienteRepo.Insert(modelo);
        }

        public async Task<bool> Update(Cliente modelo)
        {
            return await _clienteRepo.Update(modelo);
        }
    }
}
