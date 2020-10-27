using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IClienteProdutoRepository: IBaseRepository<ClienteProduto>
    {
        Task<IEnumerable<ClienteProduto>> GetAllWithInclude();
        Task<IEnumerable<ClienteProduto>> GetByCilent(long clientId);
        Task<IEnumerable<ClienteProduto>> GetByProd(long prodId);
        bool ExistRelaionship(ClienteProduto cliProd);
        bool ExistBarCode(ClienteProduto cliProd);
    }
}
