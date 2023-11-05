using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Entities.UserAccount;

public class UserEntity
{
    public int UserId { get; init; }

    [StringLength(45, MinimumLength = 2)]
    public string? Name { get; set; }

    [StringLength(45, MinimumLength = 3)]
    public string? UserName { get; set; }

    [StringLength(16, MinimumLength = 8, ErrorMessage = "A palavra-passe deve ter entre 8 a 16 cracteres")]
    [DataType(DataType.Password)]
    [Required]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^(?=.*[@])(?=.*[.]).*$")]
    public string? Email { get; set; }
}