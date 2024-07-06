using Lw.FchStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Responses
{
    public class ClientDataResponse
    {
        public int ClientId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DocumentNumber { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<int> Orders { get; set; }
        public List<ClientAddress> Addresses { get; set; }

    }
}
