using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class OrderItemAppServices : AppServices<OrderItem>, IOrderItemAppServices
{
    private readonly IOrderItemRepository _repository;
    private readonly IOrderRepository _orderRepository;
    public OrderItemAppServices(IOrderItemRepository repository, IOrderRepository orderRepository) : base(repository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
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

        var addedOrderItem = await _repository.Add(orderItem);

        var order = await _orderRepository.GetById(orderId);
        if (order != null)
        {
            order.TotalValue += unitPrice * amount;
            await _orderRepository.Update(order);
        }

        return addedOrderItem;
    }

}
