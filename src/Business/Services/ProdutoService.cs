using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProdutoService: BaseService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteProdutoRepository _clienteProdRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IClienteProdutoRepository clienteProdRepository,
                              INotificator notificator): base(notificator)
        {
            _produtoRepository = produtoRepository;
            _clienteProdRepository = clienteProdRepository;
        }

        #region [ActionMethods]
        public async Task<long> Create(Produto entity)
        {
            if (!IsValid(entity))
                return -1;

            return await _produtoRepository.Create(entity);
        }

        public async Task Update(Produto entity)
        {
            if (!IsValid(entity))
                return;

            await _produtoRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var prod = await _produtoRepository.SearchId(id);

            if (prod != null)
            {
                var rel = await _clienteProdRepository.GetByProd(id);

                if (rel != null)
                {
                    Notify("Existem relacionamentos com este cliente. Exclusão não permitida.");
                    return;
                }
                
                await _produtoRepository.Delete(prod);
            }
            else
                return;
            
        }
        #endregion

        #region [SearchMethods]
        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<Produto> SearchId(long id)
        {
            return await _produtoRepository.SearchId(id);
        }
        #endregion

        #region [ValidateMethods]
        public bool ExistCode(Produto entity)
        {
            return _produtoRepository.ExistCode(entity);
        }

        public bool ExistDescription(Produto entity)
        {
            return _produtoRepository.ExistDescription(entity);
        }

        private bool IsValid(Produto entity)
        {
            if (!ExecuteValidation(new ProdutoValidation(), entity))
                return false;

            if (ExistCode(entity))
            {
                Notify("Já existe um produto com o mesmo código.");
                return false;
            }

            if (ExistDescription(entity))
            {
                Notify("Já existe um produto com a mesma descrição.");
                return false;
            }

            return true;
        }
        #endregion
    }
}
