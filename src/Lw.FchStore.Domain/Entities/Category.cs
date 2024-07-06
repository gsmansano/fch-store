using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Domain.Entities
{

    public class Category

    {
        [Key]
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        
    }

    public class CategoryTree
    {
        public Category Category { get; set; }
        public List<Category> Children { get; set; }


    }
}
