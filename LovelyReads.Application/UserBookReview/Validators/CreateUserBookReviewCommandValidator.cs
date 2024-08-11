using FluentValidation;
using LovelyReads.Application.UserBookReview.Commands.CreateBookReview;

namespace LovelyReads.Application.UserBookReview.Validators;

public class CreateUserBookReviewCommandValidator : AbstractValidator<CreateUserBookReviewCommand>
{
	public CreateUserBookReviewCommandValidator()
	{
        //Ver se estas validações para os Ids é de fato válida, já que são campos obrigatórios para persistir a entidade
        RuleFor(br => br.IdUser)
            .NotEmpty()
            .WithMessage("IdUser's field mustn't be empty.")
            .NotNull()
            .WithMessage("IdUser's field mustn't be null.");

        RuleFor(br => br.IdBook)
            .NotEmpty()
            .WithMessage("IdBook's field mustn't be empty.")
            .NotNull()
            .WithMessage("IdBook's field mustn't be null.");

        RuleFor(br => br.Comment)
               .NotEmpty()
               .WithMessage("Comment's field mustn't be empty.")
               .NotNull()
               .WithMessage("Comment's field mustn't be null.")
               .MaximumLength(254)
               .WithMessage("Comment's maximum length is around 254 characters.");

        RuleFor(br => br.Rating)
               .NotEmpty()
               .WithMessage("Rating's field mustn't be empty.")
               .NotNull()
               .WithMessage("Rating's field mustn't be null.")
               .Must(rating => rating >= 1 && rating <= 5)
               .WithMessage("Rating must be between 1 and 5.");
    }
}
