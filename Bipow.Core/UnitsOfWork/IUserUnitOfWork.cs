using Bipow.Domain.Aggregates;
using ErrorOr;

namespace Bipow.Core.UnitsOfWork;

public interface IUserUnitOfWork
{
    Task<ErrorOr<Created>> RegisterUserAsync(UserAggregate newUser);
    Task<ErrorOr<Created>> UpdateUserAsync(UserAggregate newUser);

    Task<ErrorOr<Created>> AddAddressUserAsync(UserAggregate newUser);
    Task<ErrorOr<Created>> UpdateAddressUserAsync(UserAggregate newUser);
    Task<ErrorOr<Created>> DeleteAddressUserAsync(UserAggregate newUser);

    Task<ErrorOr<Created>> AddBillingAddressUserAsync(UserAggregate newUser);
    Task<ErrorOr<Created>> UpdateBillingAddressUserAsync(UserAggregate newUser);
    Task<ErrorOr<Created>> DeleteBillingAddressUserAsync(UserAggregate newUser);

    Task<ErrorOr<Created>> ConfirmUserEmailAsync(UserAggregate newUser);
    Task<ErrorOr<Created>> DeactivateUserAsync(UserAggregate newUser);

}
