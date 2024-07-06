using FluentValidation;
using LovelyReads.Application.Genre.Commands.CreateGenre;

namespace LovelyReads.Application.Genre.Validators;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
	public CreateGenreCommandValidator()
	{
		RuleFor(g => g.Description)
			.NotEmpty()
			.WithMessage("Genre is required.")
			.NotNull()
            .WithMessage("Genre is required.")
            .MaximumLength(150);
	}
}
