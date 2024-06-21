using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Unit;

public class AddUnitRequest
{
    [Required, MinLength(2), MaxLength(500)]
    public string Name { get; set; }
}

public class EditUnitRequest : AddUnitRequest
{
    [Required]
    public bool IsActive { get; set; }
}