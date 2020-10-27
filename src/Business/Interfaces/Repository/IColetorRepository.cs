using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IColetorRepository: IBaseRepository<Coletor>
    {
        Task<Coletor> SearchIdWitoutTracking(long id);
        bool ExistNumber(Coletor coletor);
    }
}
