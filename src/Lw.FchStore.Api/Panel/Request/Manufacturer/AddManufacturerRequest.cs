using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Manufacturer;

public class AddManufacturerRequest
{
    [Required, MinLength(2), MaxLength(500)]
    public string Name { get; set; }

}

public class EditManufacturerRequest : AddManufacturerRequest
{
    [Required]
    public bool IsActive { get; set; }

}