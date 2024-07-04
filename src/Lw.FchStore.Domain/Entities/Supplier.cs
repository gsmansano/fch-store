using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Entities
{

    // supplier entity.
    // more attributes to be added later
    public class Supplier
    {
        [Key]
        public int SupplierId{ get; set; }
        public string Name { get; set; }

        public string FullAddress { get; set; }
        public string ZipCode { get; set; }
        public string ContactName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string VatNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }


        // telefone, email, endereco, contact name, vatnumber (implementar ao long do projeto db-backend-frontend)
    }
}
