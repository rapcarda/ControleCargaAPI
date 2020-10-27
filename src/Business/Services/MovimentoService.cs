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

        public async Task<IEnumerable<Movimento>> GetMovimentoWithItem()
        {
            return await _movimentoRepository.GetMovimentoWithItem();
        }
    }
}
