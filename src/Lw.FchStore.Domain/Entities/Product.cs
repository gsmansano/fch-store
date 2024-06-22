using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int ManufacturerId { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
   
        // implementar repo, map, appservices, tabelas e controller (telas p tudo menos orderitem,)

        // product - tela p criar editar remover / listar tudo
        // order - so fazer list
        // client - so list tb
        // clientaddress - n faz nd kkk

    }

}
