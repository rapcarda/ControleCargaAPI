using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClienteProdutoService: BaseService<ClienteProduto>, IClienteProdutoService
    {
        private readonly IClienteProdutoRepository _clienteProdutoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentoRepository _movimentoRepository;

        public ClienteProdutoService(IClienteProdutoRepository clienteProdutoRepository,
                                     IClienteRepository clienteRepository,
                                     IProdutoRepository produtoRepository,
                                     IMovimentoRepository movimentoRepository,
                                     INotificator notificator): base(notificator)
        {
            _clienteProdutoRepository = clienteProdutoRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _movimentoRepository = movimentoRepository;
        }

        #region [ActionMethods]
        public async Task<long> Create(ClienteProduto entity)
        {
            if (!IsValid(entity))
                return -1;

            return await _clienteProdutoRepository.Create(entity);
        }

        public async Task Update(ClienteProduto entity)
        {
            if (!IsValid(entity))
                return;

            await _clienteProdutoRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var rel = await _clienteProdutoRepository.SearchId(id);

            if (rel != null)
            {
                if (_movimentoRepository.HasMovimByCliProd(id))
                {
                    Notify("Existem movimentações com este cliente e produto. Exclusão não permitida.");
                    return;
                }

                await _clienteProdutoRepository.Delete(rel);
            }

            
        }
        #endregion

        #region [SearchMethods]
        public async Task<IEnumerable<ClienteProduto>> GetAll()
        {
            return await _clienteProdutoRepository.GetAll();
        }

        public async Task<IEnumerable<ClienteProduto>> GetAllWithInclude()
        {
            return await _clienteProdutoRepository.GetAllWithInclude();
        }

        public async Task<ClienteProduto> SearchId(long id)
        {
            return await _clienteProdutoRepository.SearchId(id);
        }
        #endregion

        #region [ValidateMethods]
        public bool ExistBarCode(ClienteProduto entity)
        {
            return _clienteProdutoRepository.ExistBarCode(entity);
        }

        public bool ExistRelaionship(ClienteProduto entity)
        {
            return _clienteProdutoRepository.ExistRelaionship(entity);
        }

        private bool ExistClient(ClienteProduto entity)
        {
            var client = _clienteRepository.SearchId(entity.ClienteId);

            return client.Result == null ? false : true;
        }

        private bool ExistProduct(ClienteProduto entity)
        {
            var prod = _produtoRepository.SearchId(entity.ProdutoId);

            return prod.Result == null ? false : true;
        }

        private bool IsValid(ClienteProduto entity)
        {
            if (!ExecuteValidation(new ClienteProdutoValidation(), entity))
                return false;

            if (ExistBarCode(entity))
            {
                Notify("Código de Barras já utilizado em outra vinculação Cliente x Produto");
                return false;
            }

            if (ExistRelaionship(entity))
            {
                Notify("Relacionamento já existe.");
                return false;
            }

            if (!ExistClient(entity))
            {
                Notify("Cliente não cadastrado.");
                return false;
            }

            if (!ExistProduct(entity))
            {
                Notify("Produto não cadastrado.");
                return false;
            }

            return true;
        }

        #endregion


    }
}
