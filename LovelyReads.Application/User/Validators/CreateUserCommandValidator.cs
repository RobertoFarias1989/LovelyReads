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
                .WithMessage("FullName is required.")
            .NotNull()
                .WithMessage("FullName is required.")
            .MaximumLength(150)
                .WithMessage("FullName's maximum length is around 150 characters.");

            RuleFor(u => u.CPFNumber)
           .NotEmpty()
               .WithMessage("CPFNumber is required.")
           .NotNull()
               .WithMessage("CPFNumber is required.")
           .MaximumLength(11)
               .WithMessage("CPFNumber's maximum length is around 11 characters.")
            .Must(IsCPFValidate)
               .WithMessage("A valid CPFNumber is required.");

            RuleFor(u => u.EmailAddress)
            .NotEmpty()
               .WithMessage("EmailAddress is required.")
           .NotNull()
               .WithMessage("EmailAddress is required.")
           .EmailAddress()
               .WithMessage("A valid email address is required.")
           .MaximumLength(100)
               .WithMessage("EmailAddress's maximum length is around 100 characters.");

            RuleFor(u => u.Street)
            .NotEmpty()
               .WithMessage("Street is required.")
           .NotNull()
               .WithMessage("Street is required.")
           .MaximumLength(100)
               .WithMessage("Street's maximum length is around 100 characters.");

            RuleFor(u => u.City)
               .NotEmpty()
                  .WithMessage("City is required.")
              .NotNull()
                  .WithMessage("City is required.")
              .MaximumLength(100)
                  .WithMessage("City's maximum length is around 100 characters.");

            RuleFor(u => u.State)
               .NotEmpty()
                  .WithMessage("State is required.")
               .NotNull()
                  .WithMessage("State is required.")
               .MaximumLength(100)
                  .WithMessage("State's maximum length is around 100 characters.");

            RuleFor(u => u.PostalCode)
                .NotEmpty()
                   .WithMessage("PostalCode is required.")
                .NotNull()
                   .WithMessage("PostalCode is required.")
                .MaximumLength(100)
                   .WithMessage("PostalCode's maximum length is around 100 characters.");

            RuleFor(u => u.Country)
                .NotEmpty()
                   .WithMessage("Country is required.")
                .NotNull()
                   .WithMessage("Country is required.")
                .MaximumLength(50)
                   .WithMessage("Country's maximum length is around 50 characters.");

        }

        public bool IsCPFValidate(string number)
        {
            // Verifica se o comprimento do número é maior que 11
            if (number.Length > 11)
                return false;

            // Preenche com zeros à esquerda se o comprimento for menor que 11
            while (number.Length != 11)
                number = '0' + number;

            // Verifica se todos os dígitos são iguais
            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (number[i] != number[0])
                    igual = false;

            // Se todos os dígitos são iguais ou é um número específico inválido, retorna falso
            if (igual || number == "12345678909")
                return false;

            // Converte os caracteres em inteiros e armazena em um array
            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(number[i].ToString());

            // Calcula o primeiro dígito verificador
            /*var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;*/

            // Calcula o segundo dígito verificador
            /*soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;*/

            return true;
        }


    }
}
