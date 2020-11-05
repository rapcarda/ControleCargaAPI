using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MovimentoRepository: BaseRepository<Movimento>, IMovimentoRepository
    {
        private readonly IClienteProdutoRepository _clienteProdutoRepository;
        public MovimentoRepository(IClienteProdutoRepository clienteProdutoRepository,
                                   ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
            _clienteProdutoRepository = clienteProdutoRepository;
        }

        public async Task<IEnumerable<Movimento>> GetMovimentoWithItem(FilterMovim filter)
        {
            var item = _db.Set<ItemMovimento>();

            var movimento = await DBSet.AsNoTracking()
                .Include(u => u.Usuario)
                .Include(f => f.Frota)
                //.Include(i => i.ItemMovimento).ThenInclude(x => x.ClienteProduto).ThenInclude(x => x.Cliente)
                //.Include(i => i.ItemMovimento).ThenInclude(x => x.ClienteProduto).ThenInclude(x => x.Produto)
                .Where(x => x.DataHoraInicial >= filter.DataHoraInicial && x.DataHoraInicial <= filter.DataHoraFinal.AddDays(1))
                .ToListAsync();

            var cliprod = await _clienteProdutoRepository.GetAllWithInclude();

            var itemMovim = await item.AsNoTracking()
                .GroupBy(x => new { x.ClienteProdutoId, x.MovimentoId })
                .Select(g => new { 
                    ClienteProdutoId = g.Key.ClienteProdutoId,
                    MovimentoId = g.Key.MovimentoId,
                    Qtd = g.Sum(x => x.Qtd) 
                }).ToListAsync();

            movimento.ForEach(x =>
            {
                var group = itemMovim.Where(i => i.MovimentoId == x.Id);
                var itemList = new List<ItemMovimento>();
                foreach (var item in group)
                {
                    
                    var rel = cliprod.FirstOrDefault(r => r.Id == item.ClienteProdutoId);

                    var itMv = new ItemMovimento
                    {
                        ClienteProdutoId = item.ClienteProdutoId,
                        ClienteProduto = rel,
                        MovimentoId = item.MovimentoId,
                        Movimento = x,
                        Qtd = item.Qtd
                    };

                    itemList.Add(itMv);
                }

                x.ItemMovimento = itemList;
            });

            return movimento;
        }

        public bool HasMovimByColetor(long coletorId)
        {
            return DBSet.Any(x => x.ColetorId == coletorId);
        }

        public bool HasMovimByFrota(long frotaId)
        {
            return DBSet.Any(x => x.FrotaId == frotaId);
        }

        public bool HasMovimByUsuario(long usuarioId)
        {
            return DBSet.Any(x => x.UsuarioId == usuarioId);
        }

        public bool HasMovimByCliente(long clienteId)
        {
            return DBSet.Any(x => x.ItemMovimento.Any(i => i.ClienteProduto.ClienteId == clienteId));
        }

        public bool HasMovimByCliProd(long cliprodId)
        {
            return DBSet.Any(x => x.ItemMovimento.Any(i => i.ClienteProdutoId == cliprodId));
        }
    }
}
