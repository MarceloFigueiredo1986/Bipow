using Bipow.Components.UserSession.Model;
using Bipow.Core.UnitsOfWork;
using Bipow.Infrastructure.Session;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Bipow.Components.UserSession;

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
public sealed partial class Login
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
{

    [Inject]
    public IUserUnitOfWork _userUnitOfWork { get; set; }

    [Inject]
    public ILogger<Login> _logger { get; set; }

    [Inject]
    public ISessionCache _sessionCache { get; set; }

    public LoginModel _credencials { get; set; } = new();

    [CascadingParameter]
    public BlazoredModalInstance Modal { get; set; }

    private enum LoginStatus
    {
        None,
        LoginIn,
        Blocked
    }

    public async Task SuccessLogin()
    {
        _logger.LogInformation("Login success");

        _sessionCache

        await Task.Delay(1000);
        await Modal.CloseAsync();
    }

    public async Task FailedLogin()
    {
        await Task.Delay(1000);
        if (_loginAttempts == _maximumFailedAttempts)
            _loginStatus = LoginStatus.Blocked;
        else
            _loginStatus = LoginStatus.None;

        _failedUsername = true;
          
        _logger.LogWarning("Invalid login.");
    }

    public async Task LoginProcess()
    {
        _loginAttempts++;
        await SuccessLogin();
    }

    public bool GuardClauseValid()
    {
        if (string.IsNullOrEmpty(_credencials.UserName))
        {
            _failedUsername = true;
            return false;
        }

        if (string.IsNullOrEmpty(_credencials.Password))
        {
            _failedPassword = true;
            return false;
        }

        return true;
    }

    public async Task ValidateCredencials()
    {
        try
        {
            _failedPassword = false;
            _failedUsername = false;
            _loginStatus = LoginStatus.LoginIn;

            if (!GuardClauseValid()) return;

            _ = _logger.BeginScope(_credencials);

            var validLogin = await _userUnitOfWork.ValidateLoginAsync(_credencials.UserName, _credencials.Password);
            if (validLogin.IsError)
            {
                _logger.LogError(validLogin.FirstError.Description);
                await FailedLogin();
            }
            else if (!validLogin.Value)
                await FailedLogin();
            else
                await SuccessLogin();
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex}", nameof(Login));
        }
        finally
        {
            if(_loginStatus == LoginStatus.LoginIn) 
                _loginStatus = LoginStatus.None;
        }
    }
}
