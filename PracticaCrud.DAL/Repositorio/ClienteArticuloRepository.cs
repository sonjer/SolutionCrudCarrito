using PracticaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCrud.DAL.DataContext;
using Microsoft.EntityFrameworkCore;



namespace PracticaCrud.DAL.Repositorio
{
    public class ClienteArticuloRepository : IGenericRepository<ClienteArticulo>
    {

        private readonly PracticaCarritoContext _dbcontext;
        public ClienteArticuloRepository(PracticaCarritoContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Delete(int id)
        {
            ClienteArticulo modelo = _dbcontext.ClienteArticulos.First(a => a.Id == id);
            _dbcontext.ClienteArticulos.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<ClienteArticulo> Get(int id)
        {
            return await _dbcontext.ClienteArticulos.FindAsync(id);
        }

        public async Task<IQueryable<ClienteArticulo>> GetAll()
        {
            IQueryable<ClienteArticulo> queryArtículoSQL = _dbcontext.ClienteArticulos.Include(c => c.Articulo);
            return queryArtículoSQL;
        }

        public async Task<bool> Insert(ClienteArticulo modelo)
        {
            _dbcontext.ClienteArticulos.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(ClienteArticulo modelo)
        {
            _dbcontext.ClienteArticulos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
