using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class SupplierAppServices : AppServices<Supplier>, ISupplierAppServices

{
    private readonly ISupplierRepository _repository;
    public SupplierAppServices(ISupplierRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Supplier> Add(
        string name,
        string fullAddress,
        string zipCode,
        string contactName,
        string phoneNumber,
        string emailAddress,
        string vatNumber)
    {

        var supplier = new Supplier()
        {
            CreatedAt = DateTime.UtcNow,
            Name = name,
            FullAddress = fullAddress,
            ZipCode = zipCode,
            ContactName = contactName,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress,
            VatNumber = vatNumber,
            IsActive = true

        };

        return await _repository.Add(supplier);
    }
}