
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

    protected async Task EmailFieldLeaveEvent()
    {
        try
        {
            _newRegistry.EmailError = null;

            if (string.IsNullOrEmpty(_newRegistry.Email))
                return;

            var emailInUse = await _userUnitOfWork.CheckEmailInUseAsync(_newRegistry.Email);
            if (emailInUse.IsError)
            {
                componentError += emailInUse.FirstError.Description;
                return;
            }
            
            _newRegistry.EmailInUse = emailInUse.Value;

            if (emailInUse.Value)
                _newRegistry.EmailError = "Email in use";
        }
        catch (Exception ex)
        {
            componentError += ex.Message;
        }
    }

    protected async Task UserNameFieldLeaveEvent()
    {
        try
        {
            _newRegistry.UserNameError = null;

            if (string.IsNullOrEmpty(_newRegistry.UserName))
                return;

            var userNameInUse = await _userUnitOfWork.CheckUserNameInUseAsync(_newRegistry.UserName);
            if (userNameInUse.IsError)
            {
                componentError += userNameInUse.FirstError.Description;
                return;
            }

            _newRegistry.UserNameInUse = userNameInUse.Value;

            if (userNameInUse.Value)
                _newRegistry.UserNameError = "Username in use";
        }
        catch(Exception ex)
        {
            componentError += ex.Message;
        }
    }

    protected async Task SaveAsync()
    {
        if (_newRegistry.EmailInUse || _newRegistry.UserNameInUse) return;
        _registerStatus = RegisterStatus.Registering;
        await ValidateAndRegisterAsync().ConfigureAwait(true);
    }
}