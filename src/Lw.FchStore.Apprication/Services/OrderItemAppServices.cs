using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class OrderItemAppServices : AppServices<OrderItem>, IOrderItemAppServices
{
    private readonly IOrderItemRepository _repository;

    public OrderItemAppServices(IOrderItemRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<OrderItem> AddOrderItem(int orderId, int productId, decimal unitPrice, decimal amount)
    {
        var orderItem = new OrderItem()
        {
            OrderId = orderId,
            ProductId = productId,
            UnitPrice = unitPrice,
            Amount = amount,
        };

        return await _repository.Add(orderItem);
    }

}
