using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Application.DTOs
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public int ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
        public int UnitId { get; set; }
        public string? UnitName { get; set; }
    }

}
