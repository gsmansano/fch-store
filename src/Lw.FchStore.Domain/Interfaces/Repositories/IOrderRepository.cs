using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Responses;

namespace Lw.FchStore.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrder(int id);

        Task<OrderDetailsResponse> PanelGetOrderById(int orderId);

        Task<List<OrderDetailsResponse>> GetByClientId(int clientId);

    }


}
