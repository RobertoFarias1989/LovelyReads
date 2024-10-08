﻿using FluentValidation;
using LovelyReads.Application.UserBookReview.Commands.UpdateBookReview;

namespace LovelyReads.Application.UserBookReview.Validators;

public class UpdateUserBookReviewCommandValidator : AbstractValidator<UpdateUserBookReviewCommand>
{
	public UpdateUserBookReviewCommandValidator()
	{
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
