using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Entities.Menus;

public class NavMenusEntity
{
    public int NavMenuId { get; set; }

    [Required]
    public required string Name { get; set; }
    public string? Icon { get; set; }
    
    [Required]
    public required string Href { get; set; }
}
