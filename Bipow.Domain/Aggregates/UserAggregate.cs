using Bipow.Domain.Entities.UserAccount;

namespace Bipow.Domain.Aggregates;

public class UserAggregate
{
    public UserAggregate()
    {
        User = new();
        UserMetadata = new();
        Addresses = new HashSet<UserAddressEntity>();
        BillingAddresses = new HashSet<UserBillingDetails>();
    }
    public UserEntity User { get; private set; }
    public UserMetadataEntity UserMetadata { get; private set; }
    public HashSet<UserAddressEntity> Addresses { get; set; }
    public HashSet<UserBillingDetails> BillingAddresses { get; set; }

    void SetUser(UserEntity user) => this.User = user;
    void AddAddress(UserAddressEntity userAddressEntity) => Addresses.Add(userAddressEntity);
    void AddBillingAddress(UserBillingDetails userBillingDetails) => BillingAddresses.Add(userBillingDetails);
    void SetMetadata(UserMetadataEntity userMetadataEntity) => UserMetadata = userMetadataEntity;
}