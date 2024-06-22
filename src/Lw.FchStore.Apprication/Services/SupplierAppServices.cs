using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class SupplierAppServices : AppServices<Supplier>, ISupplierAppServices

{
    public SupplierAppServices(ISupplierRepository repository) : base(repository)
    {
    }
}