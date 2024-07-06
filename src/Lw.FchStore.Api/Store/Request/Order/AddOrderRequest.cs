using Lw.FchStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Store.Request.Order;

public class AddOrderRequest
{
    public OrderStatus Status { get; set; }
    public int ClientId { get; set; }
    public decimal TotalValue { get; set; }
    public int ClientAddressId { get; set; }
    public int PaymentId { get; set; }
    public DateTime CreatedAt { get; set; }

}


public class EditOrderRequest : AddOrderRequest
{
    [Required]
    public bool IsActive { get; set; }
}
