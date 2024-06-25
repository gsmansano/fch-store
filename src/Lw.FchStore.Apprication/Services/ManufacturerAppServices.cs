using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace Lw.FchStore.Application.Services;

public class ManufacturerAppServices: AppServices<Manufacturer>, IManufacturerAppServices
{
    private readonly IManufacturerRepository _repository;

    public ManufacturerAppServices(IManufacturerRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Manufacturer> Add(string name)
    {
        var manufacturer = new Manufacturer()
        {
            Name = name,
            IsActive = true
        };

        return await _repository.Add(manufacturer);
    }

}
