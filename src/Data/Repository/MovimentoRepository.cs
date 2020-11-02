using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MovimentoRepository: BaseRepository<Movimento>, IMovimentoRepository
    {
        public MovimentoRepository(ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
        }

        public async Task<IEnumerable<Movimento>> GetMovimentoWithItem()
        {
            return await DBSet.AsNoTracking()
                .Include(u => u.Usuario)
                .Include(f => f.Frota)
                .Include(i => i.ItemMovimento).ThenInclude(x => x.ClienteProduto).ThenInclude(x => x.Cliente)
                .Include(i => i.ItemMovimento).ThenInclude(x => x.ClienteProduto).ThenInclude(x => x.Produto)
                .ToListAsync();
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
