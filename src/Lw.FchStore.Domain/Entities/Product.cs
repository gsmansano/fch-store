using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int ManufacturerId { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

    }

}
