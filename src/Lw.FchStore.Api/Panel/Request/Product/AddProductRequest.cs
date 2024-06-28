using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Product;

public class AddProductRequest
{
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public int ManufacturerId { get; set; }
    public int UnitId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
}

public class EditProductRequest : AddProductRequest
{
    [Required]
    public bool IsActive { get; set; }
}
