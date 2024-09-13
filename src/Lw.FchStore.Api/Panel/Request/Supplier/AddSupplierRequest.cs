using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Supplier;

public class AddSupplierRequest
{
    [Required, MinLength(2), MaxLength(500)]
    public string Name { get; set; }
    public string FullAddress { get; set; }
    public string ZipCode { get; set; }
    public string ContactName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string VatNumber { get; set; }
}

public class EditSupplierRequest : AddSupplierRequest
{
    [Required]
    public bool IsActive { get; set; }
}