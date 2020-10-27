using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IFrotaService: IBaseService<Frota>
    {
        Task<long> Create(Frota entity);
        Task Update(Frota entity);
        Task Delete(long id);

        Task<Frota> SearchId(long id);
        Task<IEnumerable<Frota>> GetAll();

        bool ExistPlaca(Frota entity);
    }
}
