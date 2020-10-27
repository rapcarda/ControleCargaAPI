using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity : EntityBase
    {
        Task<long> Create(TEntity entity);
        Task CreateList(IEnumerable<TEntity> listEntity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task DeleteList(IEnumerable<long> ids);

        Task<TEntity> SearchId(long id);
        bool ExistById(long id);
        Task<List<TEntity>> GetAll();
        Task<int> SaveChanges();
    }
}
