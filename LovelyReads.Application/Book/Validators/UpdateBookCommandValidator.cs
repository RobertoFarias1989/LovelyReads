using FluentValidation;
using LovelyReads.Application.Book.Commands.UpdateBook;

namespace LovelyReads.Application.Book.Validators;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
	public UpdateBookCommandValidator()
	{
        RuleFor(b => b.Title)
               .NotEmpty()
               .WithMessage("Title is required.")
               .NotNull()
               .WithMessage("Title is required.")
               .MaximumLength(150)
               .WithMessage("Title's maximum length is around 150 characters.");

        RuleFor(b => b.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .NotNull()
            .WithMessage("Description is required.")
            .MaximumLength(254)
            .WithMessage("Description's maximum length is around 254 characters.");

        RuleFor(b => b.Publisher)
            .NotEmpty()
            .WithMessage("Publisher is required.")
            .NotNull()
            .WithMessage("Publisher is required.")
            .MaximumLength(100)
            .WithMessage("Publisher's maximum length is around 100 characters.");

        RuleFor(b => b.PublishedYear)
           .NotEmpty()
           .WithMessage("PublishedYear is required.")
           .NotNull()
           .WithMessage("PublishedYear is required.");

        RuleFor(b => b.PageAmount)
           .NotEmpty()
           .WithMessage("PageAmount is required.")
           .NotNull()
           .WithMessage("PageAmount is required.");

        RuleFor(b => b.BookCover)
           .NotEmpty()
           .WithMessage("BookCover is required.")
           .NotNull()
           .WithMessage("BookCover is required.");

        RuleFor(b => b.ISBN)
            .NotEmpty()
            .WithMessage("ISBN is required.")
            .NotNull()
            .WithMessage("ISBN is required.")
            .MaximumLength(13)
            .WithMessage("ISBN's maximum length is around 13 characters.");
    }
}
