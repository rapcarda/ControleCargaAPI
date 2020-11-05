using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MovimentoService: BaseService<Movimento>, IMovimentoService
    {
        private readonly IMovimentoRepository _movimentoRepository;
        public MovimentoService(IMovimentoRepository movimentoRepository,
                                INotificator notificator): base(notificator)
        {
            _movimentoRepository = movimentoRepository;
        }

        public async Task<IEnumerable<Movimento>> GetMovimentoWithItem(FilterMovim filter)
        {
            if (!IsFilterValid(filter))
                return null;

            return await _movimentoRepository.GetMovimentoWithItem(filter);
        }

        private bool IsFilterValid(FilterMovim filter)
        {
            if (filter.DataHoraInicial == null)
            {
                Notify("Data inicial do filtro inválida.");
                return false;
            }

            if (filter.DataHoraFinal == null)
            {
                Notify("Data final do filtro inválida.");
                return false;
            }

            if (filter.DataHoraFinal < filter.DataHoraInicial)
            {
                Notify("Data final do filtro menor que data inicial.");
                return false;
            }

            return true;
        }
    }
}
