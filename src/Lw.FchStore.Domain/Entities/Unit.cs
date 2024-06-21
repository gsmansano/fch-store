using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Entities
{

    // unit entity.
    // more attributes to be added later
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
