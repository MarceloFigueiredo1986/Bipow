
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bipow.Domain.Entities.UserAccount;

public sealed class UserAddressEntity
{
    public int UserAddressId { get; set; }
    public int UserId { get; set; }
    public int Country { get; set; }

    [Required]
    [StringLength(120,MinimumLength = 10,ErrorMessage = "Insira uma morada correta")]
    public string? Address { get; set; }

    [Required]
    [RegularExpression(@"^\d{4}(-\d{3})?$", ErrorMessage = "Código Postal inválido")]
    public string? ZipCode { get; set; }
}
