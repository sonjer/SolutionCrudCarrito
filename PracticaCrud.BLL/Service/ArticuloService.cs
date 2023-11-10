using PracticaCrud.DAL.Repositorio;
using PracticaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCrud.BLL.Service
{
    public class ArticuloService : IArticuloService
    {
        private readonly IGenericRepository<Artículo> _articuloRepo;
        public ArticuloService(IGenericRepository<Artículo> articuloRepo)
        {
            _articuloRepo = articuloRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _articuloRepo.Delete(id);
        }

        public async Task<Artículo> Get(int id)
        {
            return await _articuloRepo.Get(id);
        }

        public async Task<IQueryable<Artículo>> GetAll()
        {
            return await _articuloRepo.GetAll();
        }

        public async Task<Artículo> GetByStock(int articuloStock)
        {
            IQueryable<Artículo> queryArticuloSQL = await _articuloRepo.GetAll();
            Artículo articulo = queryArticuloSQL.Where(a => a.Stock == articuloStock).FirstOrDefault();
            return articulo;
        }

        public async Task<bool> Insert(Artículo modelo)
        {
            return await _articuloRepo.Insert(modelo);
        }

        public async Task<bool> Update(Artículo modelo)
        {
            return await _articuloRepo.Update(modelo);
        }
    }
}
