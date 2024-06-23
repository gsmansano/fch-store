using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(LwContext context) : base(context)
        {
        }
    }


}
