using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Responses;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface IOrderAppServices : IAppServices<Order>
{
    Task<OrderDetailsResponse> PanelGetOrderById(int orderId);

    Task<List<OrderDetailsResponse>> GetByClientId(int clientId);

}
