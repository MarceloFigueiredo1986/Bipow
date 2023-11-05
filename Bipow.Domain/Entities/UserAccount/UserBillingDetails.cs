namespace Bipow.Domain.Entities.UserAccount;

internal class UserBillingDetails
{
    public int UserBillingId { get; set; }
    public int UserId { get; set; }
    public int? Country { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? VATCode { get; set; }
}
