using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class OrderUpdateRepository : RepositoryBase<OrderUpdate>, IOrderUpdateRepository
    {
        private LwContext _context;

        public OrderUpdateRepository(LwContext context) : base(context)
        {
            _context = context;
        }

    }


}
