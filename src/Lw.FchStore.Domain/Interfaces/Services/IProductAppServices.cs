using Lw.FchStore.Domain.Entities;

namespace Lw.FchStore.Domain.Interfaces.Services;

public interface IProductAppServices : IAppServices<Product>
{
    Task<Product> AddProduct(
    int categoryId,
    int supplierId,
    int manufacturerId,
    int unitId,
    string name,
    string description,
    decimal costPrice,
    decimal salePrice);

    Task<List<ProductListDto>> GetProductList(int pageNumber, int pageSize);

    Task<ProductDetailsDto> GetProductDetailsById(int productId);

}