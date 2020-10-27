using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService: BaseService<Usuario>, IUsuarioService
    {
        #region [Constructor]
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificator notificator): base(notificator)
        {
            _usuarioRepository = usuarioRepository;
        }
        #endregion

        #region [ActionMethods]
        public async Task<long> Create(Usuario entity)
        {
            if (!IsValid(entity))
                return -1;

            return await _usuarioRepository.Create(entity);
        }

        public async Task Update(Usuario entity)
        {
            if (!IsValid(entity))
                return;

            await _usuarioRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var user = await _usuarioRepository.SearchId(id);
            await _usuarioRepository.Delete(user);
        }
        #endregion

        #region [SearchMethods]

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<Usuario> SearchId(long id)
        {
            return await _usuarioRepository.SearchId(id);
        }

        public async Task<Usuario> FindUserByLoginAndPassword(string login, string password)
        {
            return await _usuarioRepository.FindUserByLoginAndPassword(login, password); 
        }
        #endregion

        #region [Valitations]
        public bool ExistLogin(Usuario user)
        {
            return _usuarioRepository.ExistLogin(user);
        }

        public bool ExistName(Usuario user)
        {
            return _usuarioRepository.ExistName(user);
        }

        public bool ExistCode(Usuario user)
        {
            return _usuarioRepository.ExistCode(user);
        }

        private bool IsValid(Usuario entity)
        {
            if (!ExecuteValidation(new UsuarioValidation(), entity))
                return false;

            if (ExistCode(entity))
            {
                Notify("Já existe um usuário com o mesmo Código");
                return false;
            }

            if (ExistName(entity))
            {
                Notify("Já existe um usuário com o mesmo Nome");
                return false;
            }

            if (ExistLogin(entity))
            {
                Notify("Já existe um usuário com o mesmo Login");
                return false;
            }

            return true;
        }
        #endregion
    }
}
