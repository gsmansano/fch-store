using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Store.Request.OrderItem;

public class AddOrderItemRequest
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Amount { get; set; }

}


public class EditOrderItemRequest : AddOrderItemRequest
{

}
