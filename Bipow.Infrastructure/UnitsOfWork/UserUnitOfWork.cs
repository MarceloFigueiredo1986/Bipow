using Bipow.Core.UnitsOfWork;
using Bipow.Domain.Aggregates;
using ErrorOr;

namespace Bipow.Infrastructure.UnitsOfWork;

public sealed class UserUnitOfWork : IUserUnitOfWork
{
    public Task<ErrorOr<Created>> AddAddressUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> AddBillingAddressUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> ConfirmUserEmailAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> DeactivateUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> DeleteAddressUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> DeleteBillingAddressUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> RegisterUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> UpdateAddressUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> UpdateBillingAddressUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<Created>> UpdateUserAsync(UserAggregate newUser)
    {
        throw new NotImplementedException();
    }
}
