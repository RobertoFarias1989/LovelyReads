using FluentValidation;
using LovelyReads.Application.Login.Commands;
using System.Text.RegularExpressions;

namespace LovelyReads.Application.Login.Validators;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(l => l.EmailAddress)
          .NotEmpty()
               .WithMessage("EmailAddress's field mustn't be empty.")
           .NotNull()
               .WithMessage("EmailAddress's field mustn't be null.")
           .EmailAddress()
               .WithMessage("A valid email address is required.")
           .MaximumLength(100)
               .WithMessage("EmailAddress's maximum length is around 100 characters.");

        RuleFor(u => u.PasswordValue)
                .NotEmpty()
                    .WithMessage("PasswordValue's field mustn't be empty.")
                .NotNull()
                    .WithMessage("PasswordValue's field mustn't be null.")
                .MaximumLength(100)
                    .WithMessage("PasswordValue's maximum length is around 100 characters.")
                .Must(ValidPassword)
                     .WithMessage("Password must contain at least 8 characters, a number," +
               "one uppercase letter, one lowercase letter and one special character.");
    }

    public bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
