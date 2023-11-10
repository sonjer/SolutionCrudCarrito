using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCrud.Models;
using PracticaCrud.DAL.DataContext;

namespace PracticaCrud.DAL.Repositorio
{
    public class ArticuloRepository : IGenericRepository<Artículo>
    {
        private readonly PracticaCarritoContext _dbcontext;
        public ArticuloRepository(PracticaCarritoContext context)
        {
            _dbcontext = context;
        }   
        public async Task<bool> Delete(int id)
        {
            Artículo modelo = _dbcontext.Artículos.First(a => a.Codigo == id);
            _dbcontext.Artículos.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Artículo> Get(int id)
        {
            return await _dbcontext.Artículos.FindAsync(id);
        }

        public async Task<IQueryable<Artículo>> GetAll()
        {
            IQueryable<Artículo> queryArtículoSQL = _dbcontext.Artículos;
            return queryArtículoSQL;
        }

        public async Task<bool> Insert(Artículo modelo)
        {
            _dbcontext.Artículos.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Artículo modelo)
        {
            _dbcontext.Artículos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
