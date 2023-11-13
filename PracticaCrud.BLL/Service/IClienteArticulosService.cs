using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCrud.Models;


namespace PracticaCrud.BLL.Service
{
    public interface IClienteArticulosService
    {
        Task<bool> Insert(ClienteArticulo modelo);
        Task<bool> Update(ClienteArticulo modelo);
        Task<bool> Delete(int id);
        Task<ClienteArticulo> Get(int id);
        Task<IQueryable<ClienteArticulo>> GetAll();
    }
}
