using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Order;

public class AddOrderRequest
{
    public int Status { get; set; }
    public int ClientId { get; set; }
    public decimal TotalValue { get; set; }
    public int ClientAddressId { get; set; }
    public int PaymentId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class EditOrderRequest : AddOrderRequest
{
    public bool IsActive { get; set; }
}
