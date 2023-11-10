using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCrud.Models;
using PracticaCrud.DAL.DataContext;

namespace PracticaCrud.DAL.Repositorio
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly PracticaCarritoContext _dbcontext;
        public ClienteRepository(PracticaCarritoContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Delete(int id)
        {
            Cliente modelo = _dbcontext.Clientes.First(a => a.Id == id);
            _dbcontext.Clientes.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Get(int id)
        {
            return await _dbcontext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> GetAll()
        {
            IQueryable<Cliente> queryClienteSQL = _dbcontext.Clientes;
            return queryClienteSQL;
        }

        public async Task<bool> Insert(Cliente modelo)
        {
            _dbcontext.Clientes.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Cliente modelo)
        {
            _dbcontext.Clientes.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
