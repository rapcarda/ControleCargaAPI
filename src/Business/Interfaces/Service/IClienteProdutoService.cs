using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IClienteProdutoService: IBaseService<ClienteProduto>
    {
        Task<long> Create(ClienteProduto entity);
        Task Update(ClienteProduto entity);
        Task Delete(long id);

        Task<ClienteProduto> SearchId(long id);
        Task<IEnumerable<ClienteProduto>> GetAll();
        Task<IEnumerable<ClienteProduto>> GetAllWithInclude();

        bool ExistRelaionship(ClienteProduto entity);
        bool ExistBarCode(ClienteProduto entity);
    }
}
