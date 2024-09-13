using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface ISupplierAppServices : IAppServices<Supplier>
{
    Task<Supplier> Add(
        string name,
        string fullAddress,
        string zipCode,
        string contactName,
        string phoneNumber,
        string emailAddress,
        string vatNumber)
        ;

}
