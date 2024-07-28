using FluentValidation;
using LovelyReads.Application.Genre.Commands.UpdateGenre;

namespace LovelyReads.Application.Genre.Validators
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(g => g.Description)
             .NotEmpty()
             .WithMessage("Description's field musn't be empty.")
             .NotNull()
             .WithMessage("Description's field musn't be null.")
             .MaximumLength(150)
             .WithMessage("Description' s maximun lenght is around 150.");
        }
    }
}
