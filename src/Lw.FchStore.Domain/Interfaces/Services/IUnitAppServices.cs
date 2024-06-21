using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface IUnitAppServices : IAppServices<Unit>
{
    Task<Unit> Add(string name);
    
}