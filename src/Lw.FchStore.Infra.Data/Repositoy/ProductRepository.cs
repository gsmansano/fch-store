using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(LwContext context) : base(context)
        {
        }
    }


}
