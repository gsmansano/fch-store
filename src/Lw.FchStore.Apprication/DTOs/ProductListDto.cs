using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Application.DTOs
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerName { get; set; }
        public string UnitName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
