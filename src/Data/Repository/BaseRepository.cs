using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        #region [Properties]
        protected readonly ControleCargaContext _db;
        protected readonly DbSet<TEntity> DBSet;
        #endregion

        #region [Constructor]
        public BaseRepository(ControleCargaContext db)
        {
            _db = db;
            DBSet = db.Set<TEntity>();
        }
        #endregion

        #region [ActionMethods]
        public virtual async Task<long> Create(TEntity entity)
        {
            _db.Add(entity);
            await SaveChanges();
            return entity.Id;
        }

        public virtual async Task CreateList(IEnumerable<TEntity> listEntity)
        {
            foreach (var entity in listEntity)
            {
                await Create(entity);
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            _db.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _db.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteList(IEnumerable<long> ids)
        {
            foreach (var id in ids)
            {
                var entity = await SearchId(id);

                if (entity != null)
                {
                    await Delete(entity);
                }
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        #endregion

        #region [SearchMethods]

        public virtual bool ExistById(long id)
        {
            return DBSet.AsNoTracking().Any(x => x.Id == id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DBSet.ToListAsync();
        }

        public virtual async Task<TEntity> SearchId(long id)
        {
            return await DBSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
