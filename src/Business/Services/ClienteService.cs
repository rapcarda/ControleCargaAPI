using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClienteService: BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteProdutoRepository _clienteProdRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              IClienteProdutoRepository clienteProdRepository,
                              INotificator notificator): base(notificator)
        {
            _clienteRepository = clienteRepository;
            _clienteProdRepository = clienteProdRepository;
        }

        #region [ActionMethods]
        public async Task<long> Create(Cliente entity)
        {
            if (!IsValid(entity))
                return -1;

            return await _clienteRepository.Create(entity);
        }

        public async Task Update(Cliente entity)
        {
            if (!IsValid(entity))
                return;

            await _clienteRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var client = await _clienteRepository.SearchId(id);

            if (client != null)
            {
                var rel = await _clienteProdRepository.GetByCilent(id);

                if (rel != null)
                {
                    Notify("Existem relacionamentos com este cliente. Exclusão não permitida.");
                    return;
                }

                await _clienteRepository.Delete(client);
            }
            else
                return;
        }

        #endregion

        #region [SearchMethods]
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> SearchId(long id)
        {
            return await _clienteRepository.SearchId(id);
        }
        #endregion

        #region [ValidateMethods]
        public bool ExistCode(Cliente entity)
        {
            return _clienteRepository.ExistCode(entity);
        }

        public bool ExistDescription(Cliente entity)
        {
            return _clienteRepository.ExistDescription(entity);
        }

        private bool IsValid(Cliente entity)
        {
            if (!ExecuteValidation(new ClienteValidation(), entity))
                return false;

            if (ExistCode(entity))
            {
                Notify("Já existe um cliente com o mesmo código.");
                return false;
            }

            if (ExistDescription(entity))
            {
                Notify("Já existe um cliente com a mesma descrição.");
                return false;
            }

            return true;
        }
        #endregion
    }
}
