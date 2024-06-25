using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class ClientAddress
    {
        [Key]
        public int ClientAddressId { get; set; } // auto increment
        public int ClientId { get; set; }

        public string FullAddress { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
