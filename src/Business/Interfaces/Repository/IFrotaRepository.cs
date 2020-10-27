using Business.Models;

namespace Business.Interfaces.Repository
{
    public interface IFrotaRepository: IBaseRepository<Frota>
    {
        bool ExistPlaca(Frota frota);
    }
}
