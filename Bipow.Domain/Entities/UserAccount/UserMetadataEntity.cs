namespace Bipow.Domain.Entities.UserAccount;

public sealed class UserMetadataEntity
{
    public int UserMetadataId { get; set; }
    public int UserId { get; set; } 
    public bool UserEmailConfirmed { get; set; }
    public bool IsStoreManager { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset? LastUpdatedDate { get; set; }
    public DateTimeOffset? DeactivateAccountDate { get; set; } //set when the user deletes the account
    public DateTimeOffset? LastPasswordRecoveryDate { get; set; }
}