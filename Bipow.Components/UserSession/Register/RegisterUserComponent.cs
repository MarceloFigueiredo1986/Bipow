
using Bipow.Core.Models;
using Bipow.Core.UnitsOfWork;
using Bipow.Domain.Aggregates;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace Bipow.Components.UserSession.Register;
public class RegisterUserComponent : ComponentBase
{
    [Inject]
    private IUserUnitOfWork _userUnitOfWork { get; set; }

    [CascadingParameter]
    public BlazoredModalInstance Modal { get; set; }

    [Inject]
    private IModalService modalService { get; set; }

    protected RegisterModel _newRegistry = new();
    protected RegisterStatus _registerStatus;
    protected enum RegisterStatus
    {
        None,
        Registering,
        Blocked
    }

    protected string? componentError;

    protected async Task ValidateAndRegisterAsync()
    {
        try
        {
            _newRegistry.ClearErrorMessages();
            await Task.Delay(1000);
            var newUser = new UserAggregate();
            var validations = newUser.SetUser(_newRegistry.UserName, _newRegistry.Name, _newRegistry.Password, _newRegistry.PasswordConfirmation, _newRegistry.Email);

            if (validations is not null && validations.Any())
            {
                _newRegistry.ModelValid(validations);
                return;
            }

            var persistUserResult = await _userUnitOfWork.RegisterUserAsync(newUser);

            if (persistUserResult.IsError)
            {
                componentError += persistUserResult.FirstError.Description;
                return;
            }

            await Modal.CloseAsync();

            ModalOptions options = new ModalOptions
            {
                Size = ModalSize.Automatic,
                HideCloseButton = true,
                Position = ModalPosition.Middle
            };

            modalService.Show<Login>(string.Empty,options);
        }
        catch (Exception ex)
        {
            componentError += ex.Message;
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