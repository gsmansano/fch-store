using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface ISupplierAppServices : IAppServices<Supplier>
{
    Task<Supplier> Add(string name);
    
}