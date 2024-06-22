using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Domain.Entities
{
    public class Client
    {
        [Key] // n eh increment/identity - usar id do IAM
        public int ClientId { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
