using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public int? ClientAddressId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Client Client { get; set; }
        public virtual ClientAddress Address { get; set; }
        public virtual ICollection<OrderItem> Items { get;}

    }

    public enum OrderStatus
    {

    // falando dos enable/disable

        OPEN = 1, //n tem
        WAITING_PAYMENT = 2, //n tem
        PROCESSING = 3,     //n tem
        READY_TO_SHIP = 4,
        SHIPPED = 5,
        DELIVERED = 6,      //n tem
        COMPLETED = 7,
        REFUSED_PAYMENT = 91, //n tem
        CANCELED = 90
    }

}
