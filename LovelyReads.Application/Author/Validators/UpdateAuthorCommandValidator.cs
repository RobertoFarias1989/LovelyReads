using FluentValidation;
using LovelyReads.Application.Author.Commands.UpdateAuthor;

namespace LovelyReads.Application.Author.Validators;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(a => a.Born)
        .NotEmpty()
        .WithMessage("Born is required.")
        .NotNull()
        .WithMessage("Born is required.")
        .MaximumLength(254)
        .WithMessage("Born' s maximun lenght is around 254.");

        RuleFor(a => a.Died)
            .MaximumLength(254)
            .WithMessage("Died' s maximun lenght is around 254.");

        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .NotNull()
            .WithMessage("Description is required.")
            .MaximumLength(254)
            .WithMessage("Description' s maximun lenght is around 254.");

        RuleFor(a => a.FullName)
            .NotEmpty()
            .WithMessage("FullName is required.")
            .NotNull()
            .WithMessage("FullName is required.")
            .MaximumLength(150)
            .WithMessage("FullName' s maximun lenght is around 150.");

        RuleFor(a => a.Image)
            .NotEmpty()
            .WithMessage("Image is required.")
            .NotNull()
            .WithMessage("Image is required.");
    }
}
