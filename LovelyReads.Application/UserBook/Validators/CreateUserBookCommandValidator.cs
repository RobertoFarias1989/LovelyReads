using FluentValidation;
using LovelyReads.Application.UserBook.Commads.CreateUserBook;

namespace LovelyReads.Application.UserBook.Validators
{
    public class CreateUserBookCommandValidator : AbstractValidator<CreateUserBookCommand>
    {
        public CreateUserBookCommandValidator()
        {
            RuleFor(u => u.IdBook)
                .NotEmpty()
                .WithMessage("IdBook's field mustn't be empty.")
                .NotNull()
                .WithMessage("IdBook's field mustn't be null.");

            RuleFor(u => u.IdUser)
                .NotEmpty()
                .WithMessage("IdUser's field mustn't be empty.")
                .NotNull()
                .WithMessage("IdUser's field mustn't be null.");

            RuleFor(u => u.PageAmountToFinishRead)
                .NotEmpty()
                .WithMessage("PageAmountToFinishRead's field mustn't be empty.")
                .NotNull()
                .WithMessage("PageAmountToFinishRead's field mustn't be null.");
        }
    }
}
