using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository
{
    public class FrotaRepository: BaseRepository<Frota>, IFrotaRepository
    {
        public FrotaRepository(ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
        }

        public bool ExistPlaca(Frota frota)
        {
            return DBSet.AsNoTracking().Any(x => x.Placa == frota.Placa && x.Id != frota.Id);
        }
    }
}
