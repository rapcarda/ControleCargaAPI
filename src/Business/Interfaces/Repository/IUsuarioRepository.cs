using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> FindUserByLoginAndPassword(string login, string password);
        bool ExistCode(Usuario user);
        bool ExistName(Usuario user);
        bool ExistLogin(Usuario user);
    }
}
