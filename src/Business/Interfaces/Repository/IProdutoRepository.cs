using Business.Models;

namespace Business.Interfaces.Repository
{
    public interface IProdutoRepository: IBaseRepository<Produto>
    {
        bool ExistCode(Produto prod);
        bool ExistDescription(Produto prod);
    }
}
