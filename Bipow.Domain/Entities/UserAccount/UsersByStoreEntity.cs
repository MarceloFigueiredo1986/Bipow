using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Entities.UserAccount;

public sealed class UsersByStoreEntity
{
    [Required]
    public int StoreId { get; set; }
    [Required]
    public int UserId { get; set; }
}
