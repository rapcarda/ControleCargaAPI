using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FrotaService: BaseService<Frota>, IFrotaService
    {
        private readonly IFrotaRepository _frotaRepository;

        public FrotaService(IFrotaRepository frotaRepository,
                            INotificator notificator): base(notificator)
        {
            _frotaRepository = frotaRepository;
        }

        #region [ActionMethods]
        public async Task<long> Create(Frota entity)
        {
            if (!IsValid(entity))
                return -1;

            return await _frotaRepository.Create(entity);
        }

        public async Task Update(Frota entity)
        {
            if (!IsValid(entity))
                return;

            await _frotaRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var frota = await _frotaRepository.SearchId(id);
            
            if (frota != null)
            {
                await _frotaRepository.Delete(frota);
            }
        }
        #endregion

        #region [SearchMethods]
        public async Task<IEnumerable<Frota>> GetAll()
        {
            return await _frotaRepository.GetAll();
        }

        public async Task<Frota> SearchId(long id)
        {
            return await _frotaRepository.SearchId(id);
        }
        #endregion

        #region [ValidateMethods]
        public bool ExistPlaca(Frota entity)
        {
            return _frotaRepository.ExistPlaca(entity);
        }

        private bool IsValid(Frota entity)
        {
            if (!ExecuteValidation(new FrotaValidation(), entity))
                return false;

            if (ExistPlaca(entity))
            {
                Notify("Já existe uma frota com esta placa.");
                return false;
            }

            return true;
        }
        #endregion






    }
}
