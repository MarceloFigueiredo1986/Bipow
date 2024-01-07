using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Entities.UserAccount;

public sealed class StoreEntity
{
    [Required]
    public int StoreId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Address { get; set; }
}
