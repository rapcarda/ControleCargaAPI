using Business.Models;

namespace Business.Interfaces.Repository
{
    public interface IClienteRepository: IBaseRepository<Cliente>
    {
        bool ExistCode(Cliente client);
        bool ExistDescription(Cliente client);
    }
}
