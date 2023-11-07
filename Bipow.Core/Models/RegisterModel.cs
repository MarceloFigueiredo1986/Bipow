using System.ComponentModel.DataAnnotations;

namespace Bipow.Core.Models;

public class RegisterModel
{
    public string? UserName { get; set; }
    public string? UserNameError { get; set; }
    public string? Name { get; set; }
    public string? NameError { get; set; }
    public string? Password { get; set; }
    public string? PasswordError { get; set; }
    public string? PasswordConfirmation { get; set; }
    public string? PasswordConfirmationError { get; set; }
    public string? Email { get; set; }
    public string? EmailError { get; set; }
    public int Country { get; set; }
    public string? ZipCode { get; set; }

    public void ClearErrorMessages()
    {
        PasswordConfirmationError = null;
        EmailError = null;
        PasswordError = null;
        UserNameError = null; 
        NameError = null;
    }

    public void ModelValid(IReadOnlyList<ValidationResult> validationErrors)
    {
        foreach(var errorValidation in validationErrors)
        {
            var property = errorValidation.MemberNames.First().ToLower();
            if (property == nameof(Password).ToLower())
                PasswordError = errorValidation.ErrorMessage;
            else if (property == nameof(PasswordConfirmation).ToLower() && !string.IsNullOrEmpty(Password))
                PasswordConfirmationError = errorValidation.ErrorMessage;
            else if (property == nameof(Email).ToLower())
                EmailError = errorValidation.ErrorMessage;
            else if (property == nameof(UserName).ToLower())
                UserNameError = errorValidation.ErrorMessage;
            else if (property == nameof(Name).ToLower())
                NameError = errorValidation.ErrorMessage;
        }
    }
}
