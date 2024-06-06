using Lw.FchStore.Domain.Interfaces;

namespace Lw.FchStore.Application.Builder;

public class AppServices<TEntity> : IAppServices<TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;

    public AppServices(IRepository<TEntity> repository)
    {
        _repository = repository;
    }
    
    public void Dispose()
    {
        GC.Collect();
    }

    public async virtual Task<TEntity> Add(TEntity obj) => await _repository.Add(obj);

    public async virtual  Task<TEntity> GetById(int id) => await _repository.GetById(id);

    public async virtual  Task<IQueryable<TEntity>> GetAll(Func<TEntity, bool> query) => await _repository.GetAll(query);

    public async virtual Task<IQueryable<TEntity>> GetAll() => await _repository.GetAll();

    public async virtual Task Update(TEntity obj) => await _repository.Update(obj);

    public async virtual Task Remove(int id) => await _repository.Remove(id);
}