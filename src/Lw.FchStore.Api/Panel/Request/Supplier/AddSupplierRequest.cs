using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Supplier;

public class AddSupplierRequest
{
    [Required, MinLength(2), MaxLength(500)]
    public string Name { get; set; }
}

public class EditSupplierRequest : AddSupplierRequest
{
    [Required]
    public bool IsActive { get; set; }
}