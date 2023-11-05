
using Bipow.Core.Models;
using Bipow.Core.UnitsOfWork;
using Bipow.Domain.Aggregates;
using Microsoft.AspNetCore.Components;

namespace Bipow.Components.UserSession.Register;
public class RegisterUserComponent : ComponentBase
{
    [Inject]
    private IUserUnitOfWork _userUnitOfWork { get; set; }

    protected RegisterModel _newRegistry = new();
    protected RegisterStatus _registerStatus;
    protected enum RegisterStatus
    {
        None,
        Registering,
        Blocked
    }

    protected async Task ValidateAndRegisterAsync()
    {
        try
        {
            await Task.Delay(1000);
            var newUser = new UserAggregate();
            var validations = newUser.SetUser(_newRegistry.UserName, _newRegistry.Name, _newRegistry.Password, _newRegistry.PasswordConfirmation, _newRegistry.Email);

            if (validations is not null)
            {
                _newRegistry.ModelValid(validations);
                return;
            }

            var persistUser = await _userUnitOfWork.RegisterUserAsync(newUser);

            if (persistUser.IsError)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            _registerStatus = RegisterStatus.None;
        }
    }

    protected async Task SaveAsync()
    {
        _registerStatus = RegisterStatus.Registering;
        await ValidateAndRegisterAsync().ConfigureAwait(true);
    }
}