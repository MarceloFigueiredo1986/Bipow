using Bipow.Domain.Entities.UserAccount;
using System.ComponentModel.DataAnnotations;

namespace Bipow.Domain.Aggregates;

public class UserAggregate
{
    public UserAggregate()
    {
        User = new();
        UserMetadata = new();
        Addresses = new ();
        BillingAddresses = new ();
    }
    UserEntity User { get; set; }
    UserMetadataEntity UserMetadata { get; set; }
    List<UserAddressEntity> Addresses { get; set; }
    List<UserBillingDetails> BillingAddresses { get; set; }


    /// <summary>
    /// Add new user to aggregate
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <param name="passwordConfirmation"></param>
    /// <param name="email"></param>
    /// <returns>null if no validation erros, otherwise, returns the list of failed validations</returns>
    public IReadOnlyList<ValidationResult>? SetUser(string? userName,string? name, string? password, string? passwordConfirmation, string? email)
    {
        User.UserName = userName;
        User.Name = name;
        User.Password = password;
        User.Email = email;

        var context = new ValidationContext(User, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            User, context, results,
            validateAllProperties: true);

        if (!isValid)
            return results;

        if (password != passwordConfirmation)
            return new List<ValidationResult> { new ValidationResult("Palavra-passe e confirmação deve ser iguais", new List<string>(){ nameof(passwordConfirmation) }) };

        return null;
    }
    public IReadOnlyList<ValidationResult>? AddAddress(int country,string? address,string? zipCode)
    {
        var newAddress = new UserAddressEntity
        {
            Country = country,
            Address = address,
            ZipCode = zipCode
        };

        var context = new ValidationContext(newAddress, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            newAddress, context, results,
            validateAllProperties: true);

        if (!isValid)
            return results;

        Addresses.Add(newAddress);

        return null;
    }
    public void AddBillingAddress(int? country, string? address, string? zipCode, string? vatCode)
    {
        var newAddress = new UserBillingDetails
        {
            Country = country,
            Address = address,
            ZipCode = zipCode,
            VATCode = vatCode
        };

        BillingAddresses.Add(newAddress);
    }
    public void SetRelatedObjectsUserId(int userId)
    {
        User.UserId = userId;
        UserMetadata.UserId = userId;
        Addresses.ForEach(ad => ad.UserId = userId);
        BillingAddresses.ForEach(ad => ad.UserId = userId);
    }
    public void SetConfirmedEmail() => UserMetadata.UserEmailConfirmed = true;
    public void SetDeactivateAccount() => UserMetadata.DeactivateAccountDate = DateTimeOffset.UtcNow;
    public void SetPasswordRecovered() => UserMetadata.LastPasswordRecoveryDate = DateTimeOffset.UtcNow;
}