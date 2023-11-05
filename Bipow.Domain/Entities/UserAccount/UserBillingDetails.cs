namespace Bipow.Domain.Entities.UserAccount;

public class UserBillingDetails
{
    public int UserBillingId { get; set; }
    public int UserId { get; private set; }
    public int Country { get; private set; }
    public string Address { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    public string VATCode { get; private set; } = null!;
}
