using Bipow.Core.UnitsOfWork;
using Bipow.Domain.Aggregates;
using Bipow.Infrastructure.Database;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Bipow.Infrastructure.UnitsOfWork;

public sealed class UserUnitOfWork : IUserUnitOfWork
{
    private readonly DatabaseContext _dbAcessor;

    public UserUnitOfWork(DatabaseContext databaseService) =>
        _dbAcessor = databaseService;

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

    public async Task<ErrorOr<Created>> RegisterUserAsync(UserAggregate newUser)
    {
        using var transaction = await _dbAcessor.Database.BeginTransactionAsync();

        try
        {
            await _dbAcessor.Users.AddAsync(newUser.User);
            await _dbAcessor.UserMetadata.AddAsync(newUser.UserMetadata);
            await _dbAcessor.SaveChangesAsync();
            await transaction.CommitAsync();
            return Result.Created;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return Error.Failure(description: ex.Message);
        }
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

    public async Task<ErrorOr<bool>> CheckUserNameInUseAsync(string userName)
    {
        try
        {
            
            var userNameInBd = await _dbAcessor.Users.FirstOrDefaultAsync(a => a.UserName.ToLower() == userName.ToLower());
            return userNameInBd is not null;
        }
        catch (Exception ex)
        {
            return Error.Failure(description: ex.Message);
        }
    }

    public async Task<ErrorOr<bool>> CheckEmailInUseAsync(string email)
    {
        try
        {

            var emailInBd = await _dbAcessor.Users.FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
            return emailInBd is not null;
        }
        catch (Exception ex)
        {
            return Error.Failure(description: ex.Message);
        }
    }

    public async Task<ErrorOr<bool>> ValidateLoginAsync(string user, string pass)
    {
        try
        {
            var validLogin = await _dbAcessor.Users.
                FirstOrDefaultAsync(a => 
                a.UserName.ToLower() == user.ToLower() &&
                a.Password.ToLower() == pass.ToLower());

            return validLogin is not null;
        }
        catch (Exception ex)
        {
            return Error.Failure(description: ex.Message);
        }
    }
}