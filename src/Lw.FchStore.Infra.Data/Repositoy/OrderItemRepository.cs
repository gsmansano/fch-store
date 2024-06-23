using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(LwContext context) : base(context)
        {
        }
    }


}
