using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface IUsuarioService: IBaseService<Usuario>
    {
        Task<long> Create(Usuario entity);
        Task Update(Usuario entity);
        Task Delete(long id);

        Task<Usuario> SearchId(long id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> FindUserByLoginAndPassword(string login, string password);

        bool ExistCode(Usuario user);
        bool ExistName(Usuario user);
        bool ExistLogin(Usuario user);
    }
}
