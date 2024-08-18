using FluentValidation;
using LovelyReads.Application.User.Commands.CreateUser;

namespace LovelyReads.Application.User.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FullName)
            .NotEmpty()
                .WithMessage("FullName's field mustn't be empty.")
            .NotNull()
                .WithMessage("FullName's field mustn't be null.")
            .MaximumLength(150)
                .WithMessage("FullName's maximum length is around 150 characters.");

            RuleFor(u => u.CPFNumber)
           .NotEmpty()
               .WithMessage("CPFNumber's field mustn't be empty.")
           .NotNull()
               .WithMessage("CPFNumber's field mustn't be null.")
           .MaximumLength(11)
               .WithMessage("CPFNumber's maximum length is around 11 characters.")
            .Must(IsCpf)
               .WithMessage("A valid CPFNumber is required.");

            RuleFor(u => u.EmailAddress)
            .NotEmpty()
               .WithMessage("EmailAddress's field mustn't be empty.")
           .NotNull()
               .WithMessage("EmailAddress's field mustn't be null.")
           .EmailAddress()
               .WithMessage("A valid email address is required.")
           .MaximumLength(100)
               .WithMessage("EmailAddress's maximum length is around 100 characters.");

            RuleFor(u => u.Street)
            .NotEmpty()
               .WithMessage("Street's field mustn't be empty.")
           .NotNull()
               .WithMessage("Street's field mustn't be null.")
           .MaximumLength(100)
               .WithMessage("Street's maximum length is around 100 characters.");

            RuleFor(u => u.City)
               .NotEmpty()
                  .WithMessage("City's field mustn't be empty.")
              .NotNull()
                  .WithMessage("City's field mustn't be null.")
              .MaximumLength(100)
                  .WithMessage("City's maximum length is around 100 characters.");

            RuleFor(u => u.State)
               .NotEmpty()
                  .WithMessage("State's field mustn't be empty.")
               .NotNull()
                  .WithMessage("State's field mustn't be null.")
               .MaximumLength(100)
                  .WithMessage("State's maximum length is around 100 characters.");

            RuleFor(u => u.PostalCode)
                .NotEmpty()
                   .WithMessage("PostalCode's field mustn't be empty.")
                .NotNull()
                   .WithMessage("PostalCode's field mustn't be null.")
                .MaximumLength(100)
                   .WithMessage("PostalCode's maximum length is around 100 characters.");

            RuleFor(u => u.Country)
                .NotEmpty()
                   .WithMessage("Country's field mustn't be empty.")
                .NotNull()
                   .WithMessage("Country's field mustn't be null.")
                .MaximumLength(50)
                   .WithMessage("Country's maximum length is around 50 characters.");

        }

     
        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }


    }
}
