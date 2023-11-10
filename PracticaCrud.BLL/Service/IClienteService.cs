using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCrud.Models;

namespace PracticaCrud.BLL.Service
{
    public interface IClienteService
    {
        Task<bool> Insert(Cliente modelo);
        Task<bool> Update(Cliente modelo);
        Task<bool> Delete(int id);
        Task<Cliente> Get(int id);
        Task<IQueryable<Cliente>> GetAll();
        Task<Cliente> FindByEmailAndPassword(string email, string password);

    }
}
