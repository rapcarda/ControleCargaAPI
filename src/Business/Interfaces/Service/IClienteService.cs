using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<long> Create(Cliente entity);
        Task Update(Cliente entity);
        Task Delete(long id);

        Task<Cliente> SearchId(long id);
        Task<IEnumerable<Cliente>> GetAll();

        bool ExistCode(Cliente entity);
        bool ExistDescription(Cliente entity);
    }
}
