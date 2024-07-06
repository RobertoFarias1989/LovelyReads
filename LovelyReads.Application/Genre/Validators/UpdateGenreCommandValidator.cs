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
            .WithMessage("Genre is required.")
            .NotNull()
            .WithMessage("Genre is required.")
            .MaximumLength(150);
        }
    }
}
