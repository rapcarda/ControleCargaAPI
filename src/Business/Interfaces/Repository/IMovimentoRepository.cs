using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IMovimentoRepository: IBaseRepository<Movimento>
    {
        Task<IEnumerable<Movimento>> GetMovimentoWithItem();
        bool HasMovimByColetor(long coletorId);
        bool HasMovimByFrota(long frotaId);
        bool HasMovimByUsuario(long usuarioId);
        bool HasMovimByCliente(long clienteId);
        bool HasMovimByCliProd(long cliprodId);
    }
}
