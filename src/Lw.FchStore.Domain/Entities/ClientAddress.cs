using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class ClientAddress
    {
        [Key]
        public int ClientAddressId { get; set; } // auto increment
        public int ClientId { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
