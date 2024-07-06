using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Responses;

namespace Lw.FchStore.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ClientDataResponse> PanelGetById(int id);
    }


}
