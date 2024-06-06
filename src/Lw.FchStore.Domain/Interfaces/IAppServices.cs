namespace Lw.FchStore.Domain.Interfaces;

public interface IAppServices<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> Add(TEntity obj);
    Task<TEntity> GetById(int id);
    Task<IQueryable<TEntity>> GetAll(Func<TEntity, bool> query);
    Task<IQueryable<TEntity>> GetAll();
    Task Update(TEntity obj);
    Task Remove(int id);
}