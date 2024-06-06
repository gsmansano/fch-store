using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface IManufacturerAppServices : IAppServices<Manufacturer>
{
    Task<Manufacturer> Add(string name);
    
}