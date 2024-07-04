using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Interfaces;


// main interface with all shared functionalities.
// specific interfaces will contain entity-specific functions.
public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> Add(TEntity obj);
    Task<TEntity> GetById(int id);
    Task<IQueryable<TEntity>> GetAll(Func<TEntity, bool> query);
    TEntity FirstOrDefault(Func<TEntity, bool> query);
    Task<IQueryable<TEntity>> GetAll();
    Task Update(TEntity obj);
    Task Remove(int id);
    Task<int> SaveChanges();
}
