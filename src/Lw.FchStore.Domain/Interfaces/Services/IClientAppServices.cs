using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Responses;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface IClientAppServices : IAppServices<Client>
{
    Task<ClientDataResponse> PanelGetById(int id);

}
