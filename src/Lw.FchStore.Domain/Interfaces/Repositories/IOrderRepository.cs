using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrder(int id);
    }


}
