using FluentValidation;
using LovelyReads.Application.Genre.Commands.CreateGenre;

namespace LovelyReads.Application.Genre.Validators;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
	public CreateGenreCommandValidator()
	{
		RuleFor(g => g.Description)
			.NotEmpty()
			.WithMessage("Description's field mustn't be empty.")
			.NotNull()
            .WithMessage("Description's field mustn't be null.")
			.NotEqual("string")
			.WithMessage("Infrom a valida name for Description's field.")
			.MinimumLength(5)
			.WithMessage("Description' s minimun lenght is 5.")
            .MaximumLength(150)
			.WithMessage("Description' s maximun lenght is around 150.");
		
    }
}
