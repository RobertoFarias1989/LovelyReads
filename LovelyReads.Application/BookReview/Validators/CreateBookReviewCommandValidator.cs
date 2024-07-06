using FluentValidation;
using LovelyReads.Application.BookReview.Commands.CreateBookReview;

namespace LovelyReads.Application.BookReview.Validators;

public class CreateBookReviewCommandValidator : AbstractValidator<CreateBookReviewCommand>
{
	public CreateBookReviewCommandValidator()
	{
        RuleFor(br => br.Comment)
               .NotEmpty()
               .WithMessage("Comment is required.")
               .NotNull()
               .WithMessage("Comment is required.")
               .MaximumLength(254)
               .WithMessage("Comment's maximum length is around 254 characters.");

        RuleFor(br => br.Rating)
               .NotEmpty()
               .WithMessage("Comment is required.")
               .NotNull()
               .WithMessage("Comment is required.")
               .Must(rating => rating >= 1 && rating <= 5)
               .WithMessage("Rating must be between 1 and 5.");
    }
}
