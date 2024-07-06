using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Entities
{
    public class OrderUpdate
    {
        [Key]
        public int OrderUpdateId { get; set; }
        public int OrderId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }


    }
}
