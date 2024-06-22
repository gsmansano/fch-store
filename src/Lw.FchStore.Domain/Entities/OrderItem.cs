using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

    }

}
