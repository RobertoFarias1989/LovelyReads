using FluentValidation;
using LovelyReads.Application.Author.Commands.CreateAuthor;

namespace LovelyReads.Application.Author.Validators;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
	public CreateAuthorCommandValidator()
	{
		RuleFor(a => a.Born)
			.NotEmpty()
			.WithMessage("Born's field musn't be empty.")
			.NotNull()
			.WithMessage("Born's field musn't be null.")
			.MaximumLength(254)
			.WithMessage("Born' s maximun lenght is around 254.");

        RuleFor(a => a.Died)
            .MaximumLength(254)
            .WithMessage("Died' s maximun lenght is around 254.");

        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Description's field musn't be empty.")
            .NotNull()
            .WithMessage("Description's field musn't be null.")
            .MaximumLength(254)
            .WithMessage("Description' s maximun lenght is around 254.");

        RuleFor(a => a.FullName)
            .NotEmpty()
            .WithMessage("FullName's field musn't be empty.")
            .NotNull()
            .WithMessage("FullName's field musn't be null.")
            .MaximumLength(150)
            .WithMessage("FullName' s maximun lenght is around 150.");

        RuleFor(a => a.Image)
            .NotEmpty()
            .WithMessage("Image's field musn't be empty.")
            .NotNull()
            .WithMessage("Image's field musn't be null.");

    }
}
