using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IColetorService: IBaseService<Coletor>
    {
        Task<long> Create(Coletor entity);
        Task Update(Coletor entity);
        Task Delete(long id);

        Task<Coletor> SearchId(long id);
        Task<IEnumerable<Coletor>> GetAll();

        bool ExistNumber(Coletor entity);
    }
}
