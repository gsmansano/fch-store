using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Entities
{

    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }

}
