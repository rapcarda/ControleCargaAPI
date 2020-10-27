using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClienteProdutoRepository: BaseRepository<ClienteProduto>, IClienteProdutoRepository
    {
        public ClienteProdutoRepository(ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
        }

        public bool ExistBarCode(ClienteProduto cliProd)
        {
            return DBSet.AsNoTracking().Any(x => x.CodigoBarra == cliProd.CodigoBarra && x.Id != cliProd.Id);
        }

        public bool ExistRelaionship(ClienteProduto cliProd)
        {
            return DBSet.AsNoTracking().Any(x => (x.ClienteId == cliProd.ClienteId && x.ProdutoId == cliProd.ProdutoId) && x.Id != cliProd.Id);
        }

        public async Task<IEnumerable<ClienteProduto>> GetAllWithInclude()
        {
            return await DBSet.Include(x => x.Cliente).Include(x => x.Produto).ToListAsync();
        }

        public async Task<IEnumerable<ClienteProduto>> GetByCilent(long clientId)
        {
            return await DBSet.Where(x => x.ClienteId == clientId).ToListAsync();
        }

        public async Task<IEnumerable<ClienteProduto>> GetByProd(long prodId)
        {
            return await DBSet.Where(x => x.ProdutoId == prodId).ToListAsync();
        }
    }
}
