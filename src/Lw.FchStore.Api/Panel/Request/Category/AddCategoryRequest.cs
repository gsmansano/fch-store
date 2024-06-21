using System.ComponentModel.DataAnnotations;

namespace Lw.FchStore.Api.Panel.Request.Category;

public class AddCagegoryRequest
{
    [Required, MinLength(2), MaxLength(500)]
    public string Name { get; set; }
}

public class EditCategoryRequest : AddCagegoryRequest
{
    [Required]
    public bool IsActive { get; set; }
}