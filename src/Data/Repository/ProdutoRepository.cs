using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository
{
    public class ProdutoRepository: BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
        }

        public bool ExistCode(Produto prod)
        {
            return DBSet.AsNoTracking().Any(x => x.Codigo == prod.Codigo && x.Id != prod.Id);
        }

        public bool ExistDescription(Produto prod)
        {
            return DBSet.AsNoTracking().Any(x => x.Descricao == prod.Descricao && x.Id != prod.Id);
        }
    }
}
