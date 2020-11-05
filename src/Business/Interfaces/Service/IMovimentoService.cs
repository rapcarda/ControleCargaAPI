using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IMovimentoService: IBaseService<Movimento>
    {
        Task<IEnumerable<Movimento>> GetMovimentoWithItem(FilterMovim filter);
    }
}
