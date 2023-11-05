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

    public void ModelValid(IReadOnlyList<ValidationResult> validationErrors)
    {
        foreach(var errorValidation in validationErrors)
        {
            var property = errorValidation.MemberNames.First();
            if (property == nameof(Password))
                PasswordError = errorValidation.ErrorMessage;
            else if (property == nameof(PasswordConfirmation))
                PasswordConfirmationError = errorValidation.ErrorMessage;
            else if (property == nameof(Email))
                EmailError = errorValidation.ErrorMessage;
            else if (property == nameof(UserName))
                UserNameError = errorValidation.ErrorMessage;
            else if (property == nameof(Name))
                NameError = errorValidation.ErrorMessage;
        }
    }
}
