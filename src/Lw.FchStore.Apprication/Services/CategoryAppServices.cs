using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class CategoryAppServices : AppServices<Category>, ICategoryAppServices
{
    public CategoryAppServices(ICategoryRepository repository) : base(repository)
    {
    }

    public Task<List<CategoryTree>> GetTree()
    {
        throw new NotImplementedException();
    }
}