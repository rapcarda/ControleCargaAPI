using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Business.Models.Enums;
using Business.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ColetorService: BaseService<Coletor>, IColetorService
    {
        private readonly IColetorRepository _coletorRepository;
        private readonly IMovimentoRepository _movimentoRepository;

        public ColetorService(IColetorRepository coletorRepository,
                              IMovimentoRepository movimentoRepository,
                              INotificator notificator): base(notificator)
        {
            _coletorRepository = coletorRepository;
            _movimentoRepository = movimentoRepository;
        }

        #region [ActionMethods]
        public async Task<long> Create(Coletor entity)
        {
            entity.Imei = CreateIMEIValue(entity.Numero);
            entity.UtilizaCC = YesNo.Yes;
            if (!IsValid(entity))
                return -1;

            return await _coletorRepository.Create(entity);
        }

        public async Task Update(Coletor entity)
        {
            var coletor = await _coletorRepository.SearchIdWitoutTracking(entity.Id);

            if (coletor.Numero != entity.Numero)
            {
                Notify("Número inválido.");
                return;
            }

            entity.Imei = coletor.Imei;
            entity.LastFichaCC = coletor.LastFichaCC;
            entity.LastSincCC = coletor.LastSincCC;
            entity.UtilizaCC = coletor.UtilizaCC;

            if (!IsValid(entity))
                return;

            await _coletorRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            var coletor = await _coletorRepository.SearchId(id);

            if (coletor != null)
            {
                if (_movimentoRepository.HasMovimByColetor(id))
                {
                    Notify("Existem movimentos com este coletor. Exclusão não permitida.");
                    return;
                }

                await _coletorRepository.Delete(coletor);
            }

            return;
        }
        #endregion

        #region [SearchMethods]
        public async Task<IEnumerable<Coletor>> GetAll()
        {
            return await _coletorRepository.GetAll();
        }

        public async Task<Coletor> SearchId(long id)
        {
            return await _coletorRepository.SearchId(id);
        }
        #endregion

        #region [ValidationMethods]
        public bool ExistNumber(Coletor entity)
        {
            return _coletorRepository.ExistNumber(entity);
        }

        private bool IsValid(Coletor entity)
        {
            if (!ExecuteValidation(new ColetorValidation(), entity))
                return false;

            if (ExistNumber(entity))
            {
                Notify("Já existe um coletor com este número.");
                return false;
            }

            return true;
        }
        #endregion

        #region [UtilsMethods]
        private string CreateIMEIValue(int numero)
        {
            var format = numero.ToString().PadLeft(5, '0');
            return $"00000-00000-00000-{format}";
        }
        #endregion
    }
}
