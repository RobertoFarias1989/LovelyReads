using FluentValidation;
using LovelyReads.Application.Book.Commands.UpdateBook;

namespace LovelyReads.Application.Book.Validators;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
	public UpdateBookCommandValidator()
	{
        RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("Title's field mustn't be empty.")
                .NotNull()
                .WithMessage("Title's field mustn't be null.")
                .MaximumLength(150)
                .WithMessage("Title's maximum length is around 150 characters.");

        RuleFor(b => b.Description)
            .NotEmpty()
            .WithMessage("Description's field mustn't be empty.")
            .NotNull()
            .WithMessage("Description's field mustn't be null.")
            .MaximumLength(254)
            .WithMessage("Description's maximum length is around 254 characters.");

        RuleFor(b => b.Publisher)
            .NotEmpty()
            .WithMessage("Publisher's field mustn't be empty.")
            .NotNull()
            .WithMessage("Publisher's field mustn't be null.")
            .MaximumLength(100)
            .WithMessage("Publisher's maximum length is around 100 characters.");

        RuleFor(b => b.PublishedYear)
           .NotEmpty()
           .WithMessage("PublishedYear's field mustn't be empty.")
           .NotNull()
           .WithMessage("PublishedYear's field mustn't be null.");

        RuleFor(b => b.PageAmount)
           .NotEmpty()
           .WithMessage("PageAmount's field mustn't be empty.")
           .NotNull()
           .WithMessage("PageAmount's field mustn't be null.");

        //RuleFor(b => b.BookCover)
        //   .NotEmpty()
        //   .WithMessage("BookCover's field mustn't be empty.")
        //   .NotNull()
        //   .WithMessage("BookCover's field mustn't be null.");

        RuleFor(b => b.EditionDescription)
           .NotEmpty()
           .WithMessage("EditionDescription's field mustn't be empty.")
           .NotNull()
           .WithMessage("EditionDescription's field mustn't be null.")
           .MaximumLength(100)
           .WithMessage("EditionDescription's maximum length is around 100 characters.");

        RuleFor(b => b.ISBN)
            .NotEmpty()
            .WithMessage("ISBN's field mustn't be empty.")
            .NotNull()
            .WithMessage("ISBN's field mustn't be null.")
            .MaximumLength(13)
            .WithMessage("ISBN's maximum length is around 13 characters.");
    }
}
