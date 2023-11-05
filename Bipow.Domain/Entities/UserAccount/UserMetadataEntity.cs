namespace Bipow.Domain.Entities.UserAccount;

public sealed class UserMetadataEntity
{
    public int UserMetadataId { get; private set; }
    public int UserId { get; private set; } 
    public bool UserEmailConfirmed { get; private set; }
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset? LastUpdatedDate { get; private set; }
    /// DeactivatedAccountDate is set when the user deletes the account
    public DateTimeOffset? DeactivatedAccountDate { get; private set; }
    public DateTimeOffset? LastPasswordRecoveryDate { get; private set; }
}