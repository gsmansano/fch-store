using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface IClientAddressAppServices : IAppServices<ClientAddress>
{
    Task<ClientAddress> GetById(int clientId, int clientAddressId);
}
