using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class ProductAppServices : AppServices<Product>, IProductAppServices
{
    private readonly IProductRepository _repository;

    public ProductAppServices(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Product> AddProduct(
        int categoryId,
        int supplierId,
        int manufacturerId,
        int unitId,
        string name,
        string description,
        decimal costPrice,
        decimal salePrice)
    {
        var product = new Product()
        {
            CategoryId = categoryId,
            SupplierId = supplierId,
            ManufacturerId = manufacturerId,
            UnitId = unitId,
            Name = name,
            Description = description,
            CostPrice = costPrice,
            SalePrice = salePrice,
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        return await _repository.Add(product);
    }

}