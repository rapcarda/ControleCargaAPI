using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository
{
    public class ClienteRepository: BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ControleCargaContext controCargaContext): base(controCargaContext)
        {
        }

        public bool ExistCode(Cliente client)
        {
            return DBSet.AsNoTracking().Any(x => x.Codigo == client.Codigo && x.Id != client.Id);
        }

        public bool ExistDescription(Cliente client)
        {
            return DBSet.AsNoTracking().Any(x => x.Descricao == client.Descricao && x.Id != client.Id);
        }
    }
}
