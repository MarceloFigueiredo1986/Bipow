
namespace Bipow.Domain.Entities.UserAccount;

public sealed class UserAddressEntity
{
    public int UserAddressId { get; private set; }
    public int UserId { get; private set; }
    public int Country { get; private set; }
    public string Address { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
}
