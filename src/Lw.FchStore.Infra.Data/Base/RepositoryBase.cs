using Lw.FchStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lw.FchStore.Infra.Data.Base
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async virtual Task<TEntity> Add(TEntity obj)
        {
            DbSet.Add(obj);
            await Db.SaveChangesAsync();

            return obj;
        }

        public async virtual Task<TEntity>  GetById(int id) => await DbSet.FindAsync(id);

        public async virtual Task<IQueryable<TEntity>>  GetAll(Func<TEntity, bool> query) => DbSet.Where(query).AsQueryable();

        public async virtual Task<IQueryable<TEntity>> GetAll() => DbSet;

        public async virtual Task Update(TEntity obj)
        {
            DbSet.Update(obj);
            await Db.SaveChangesAsync();
        }

        public async virtual Task Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            await Db.SaveChangesAsync();
        }

        public Task<int> SaveChanges() => Db.SaveChangesAsync();

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        
        public TEntity FirstOrDefault(Func<TEntity, bool> query) => DbSet.FirstOrDefault(query);
   
    }
}
