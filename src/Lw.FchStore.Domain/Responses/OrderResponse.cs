using Lw.FchStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Responses
{
    public class OrderDetailsResponse
    {

        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public int ClientAddressId { get; set; }
        public int PaymentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public ClientDetailsResponse Client { get; set; }
        
        public ClientAddressResponse Address { get; set; }
    }

    public class ClientDetailsResponse
    {
        public int ClientId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ClientAddressResponse
    {
        public int ClientAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

}
