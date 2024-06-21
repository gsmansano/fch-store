using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Entities
{

    // category entity.
    // more attributes to be added later
    public class Category

    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
