using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ColetorRepository: BaseRepository<Coletor>, IColetorRepository
    {
        public ColetorRepository(ControleCargaContext controleCargaContext): base(controleCargaContext)
        {
        }

        public async Task<Coletor> SearchIdWitoutTracking(long id)
        {
            return await DBSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool ExistNumber(Coletor coletor)
        {
            return DBSet.AsNoTracking().Any(x => x.Numero == coletor.Numero && x.Id != coletor.Id);
        }
    }
}
