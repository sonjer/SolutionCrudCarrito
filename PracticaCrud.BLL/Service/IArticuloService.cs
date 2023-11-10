using PracticaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCrud.BLL.Service
{
    public interface IArticuloService
    {
        Task<bool> Insert(Artículo modelo);
        Task<bool> Update(Artículo modelo);
        Task<bool> Delete(int id);
        Task<Artículo> Get(int id);
        Task<IQueryable<Artículo>> GetAll();

        Task<Artículo> GetByStock(int articuloStock);
    }
}
