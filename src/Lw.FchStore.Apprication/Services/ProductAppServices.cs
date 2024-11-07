using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;
using Lw.FchStore.Infra.Data.Repositoy;
using Lw.FchStore.Application.DTOs;

namespace Lw.FchStore.Application.Services;

public class ProductAppServices : AppServices<Product>, IProductAppServices
{
    private readonly IProductRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IUnitRepository _unitRepository;

    public ProductAppServices(
        IProductRepository repository,
        ICategoryRepository categoryRepository,
        ISupplierRepository supplierRepository,
        IManufacturerRepository manufacturerRepository,
        IUnitRepository unitRepository
    ) : base(repository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _supplierRepository = supplierRepository;
        _manufacturerRepository = manufacturerRepository;
        _unitRepository = unitRepository;
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

    // this is create the list of products with info on supp, manuf, unit and cat
    public async Task<List<ProductListDto>> GetProductList(int pageNumber, int pageSize)
    {
        var products = await _repository.GetAll();

        var paginatedProducts = products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var productDtos = new List<ProductListDto>();

        foreach (var product in paginatedProducts)
        {
            var category = await _categoryRepository.GetById(product.CategoryId);
            var supplier = await _supplierRepository.GetById(product.SupplierId);
            var manufacturer = await _manufacturerRepository.GetById(product.ManufacturerId);
            var unit = await _unitRepository.GetById(product.UnitId);

            var productDto = new ProductListDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                CategoryName = category?.Name ?? "Unknown",
                SupplierName = supplier?.Name ?? "Unknown",
                ManufacturerName = manufacturer?.Name ?? "Unknown",
                UnitName = unit?.Name ?? "Unknown",
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };

            productDtos.Add(productDto);
        }

        return productDtos;
    }

    // this will get details of a single product for edit page
    public async Task<ProductDetailsDto> GetProductDetailsById(int productId)
    {
        var product = await _repository.GetById(productId);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {productId} not found.");
        }

        var category = await _categoryRepository.GetById(product.CategoryId);
        var supplier = await _supplierRepository.GetById(product.SupplierId);
        var manufacturer = await _manufacturerRepository.GetById(product.ManufacturerId);
        var unit = await _unitRepository.GetById(product.UnitId);

        return new ProductDetailsDto
        {
            ProductId = product.ProductId,
            CategoryId = category?.CategoryId ?? 0,
            CategoryName = category?.Name ?? "Unknown",
            SupplierId = supplier?.SupplierId ?? 0,
            SupplierName = supplier?.Name ?? "Unknown",
            ManufacturerId = manufacturer?.ManufacturerId ?? 0,
            ManufacturerName = manufacturer?.Name ?? "Unknown",
            UnitId = unit?.UnitId ?? 0,
            UnitName = unit?.Name ?? "Unknown"
        };
    }

}