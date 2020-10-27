using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IProdutoService: IBaseService<Produto>
    {
        Task<long> Create(Produto entity);
        Task Update(Produto entity);
        Task Delete(long id);

        Task<Produto> SearchId(long id);
        Task<IEnumerable<Produto>> GetAll();

        bool ExistCode(Produto entity);
        bool ExistDescription(Produto entity);
    }
}
