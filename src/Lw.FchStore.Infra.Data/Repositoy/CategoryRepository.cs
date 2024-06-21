using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(LwContext context) : base(context)
        {
        }
    }
}
