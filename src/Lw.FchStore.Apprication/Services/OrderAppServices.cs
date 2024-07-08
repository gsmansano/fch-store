using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;
using Lw.FchStore.Domain.Responses;

namespace Lw.FchStore.Application.Services;

public class OrderAppServices : AppServices<Order>, IOrderAppServices
{
    private readonly IOrderRepository _repository;

    public OrderAppServices(IOrderRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Order> AddOrder(int clientId, OrderStatus status, decimal totalValue, int clientAddressId, int paymentId)
    {
        var order = new Order()
        {
            ClientId = clientId,
            Status = status,
            TotalValue = totalValue,
            ClientAddressId = clientAddressId,
            PaymentId = paymentId,
            CreatedAt = DateTime.Now
        };

        return await _repository.Add(order);
    }

    public async Task<List<OrderDetailsResponse>> GetByClientId(int clientId)
    {
        return await _repository.GetByClientId(clientId);
    }

    public async Task<Order> GetById(int id)
    {
        return await _repository.GetOrder(id);

    }

    public async Task<OrderDetailsResponse> PanelGetOrderById(int orderId)
    {
        return await _repository.PanelGetOrderById(orderId);
    }


}
