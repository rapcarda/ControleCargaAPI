using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IMovimentoRepository: IBaseRepository<Movimento>
    {
        Task<IEnumerable<Movimento>> GetMovimentoWithItem();
    }
}
