using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
        }

        public async Task<Usuario> FindUserByLoginAndPassword(string login, string password)
        {
            return await DBSet.AsNoTracking().FirstOrDefaultAsync(x => x.Login == login && x.Senha == password);
        }

        public bool ExistLogin(Usuario user)
        {
            return DBSet.AsNoTracking().Any(x => x.Login == user.Login && x.Id != user.Id);
        }

        public bool ExistName(Usuario user)
        {
            return DBSet.AsNoTracking().Any(x => x.Nome == user.Nome && x.Id != user.Id);
        }

        public bool ExistCode(Usuario user)
        {
            return DBSet.AsNoTracking().Any(x => x.Codigo == user.Codigo && x.Id != user.Id);
        }
    }
}
