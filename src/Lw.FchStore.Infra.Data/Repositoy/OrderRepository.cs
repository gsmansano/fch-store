using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private LwContext _context;

        public OrderRepository(LwContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Order
           .Include(o => o.Client)
           .Include(o => o.Address)
           .Include(o => o.Items)
            .ThenInclude(oi => oi.Product)
           .FirstOrDefaultAsync(o => o.OrderId == id);

        }
    }


}
