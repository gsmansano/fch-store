using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Status { get; set; }
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public int ClientAddressId { get; set; }
        public int PaymentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Client Client { get; set; }
        public ClientAddress Address { get; set; }
        public ICollection<OrderItem> OrderItems { get;}

    }

}
