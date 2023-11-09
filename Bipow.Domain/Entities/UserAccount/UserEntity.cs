using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Entities.UserAccount;

public class UserEntity
{
    public int UserId { get; set; }

    [Required(ErrorMessage ="Preencha o nome")]
    [StringLength(45, MinimumLength = 2,ErrorMessage ="Deve ter entre 2 a 45 letras")]
    public required string Name { get; set; }

    [StringLength(45, MinimumLength = 3, ErrorMessage = "Deve ter entre 3 a 45 letras")]
    [Required(ErrorMessage = "Preencha o nome utilizador")]
    public required string UserName { get; set; }

    [StringLength(16, MinimumLength = 8, ErrorMessage = "A palavra-passe deve ter entre 8 a 16 cracteres")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Preencha a palavra-passe")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,16}$",ErrorMessage ="8 a 16 letras, maiúsculas, minúsculas e caracteres")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Preencha o email")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^(?=.*[@])(?=.*[.]).*$")]
    public required string Email { get; set; }
}