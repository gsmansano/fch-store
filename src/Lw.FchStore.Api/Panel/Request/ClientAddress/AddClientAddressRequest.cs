using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.ClientAddress;

public class AddClientAddressRequest
{
    [Required, MinLength(2), MaxLength(500)]
    public string FullAddress { get; set; }

    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}


public class EditClientAddressRequest : AddClientAddressRequest
{
    [Required]
    public bool IsActive { get; set; }
    public int ClientAddressId { get; set; }
    public int ClientId { get; set; }
}
