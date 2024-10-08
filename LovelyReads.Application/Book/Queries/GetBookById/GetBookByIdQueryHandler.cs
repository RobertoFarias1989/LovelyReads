﻿using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Result<BookDetailsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<BookDetailsViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetDetailsByIdAsync(request.Id);

        BookDetailsViewModel bookDetailsViewModel;


        if (book == null)
            return Result.Fail<BookDetailsViewModel>(BookErrors.NotFound);       

        if (book.UserBooks.Count > 0)
        {
            var userBookReviewsModel = book.UserBooks!
           .Where(br => br.IdBook == request.Id)
           .Select(br => new UserBookViewModel(
               br.Id,
               br.IdUser,
               br.IdBook)).ToList();

            bookDetailsViewModel = new BookDetailsViewModel(
               book.Id,
               book.Title,
               book.Description,
               book.ISBN,
               book.IdAuthor,
               book.Author!.Name.FullName,
               book.Publisher,
               book.IdGenre,
               book.Genre!.Description,
               book.PublishedYear,
               book.PageAmount,
               book.AverageRating,
               book.BookCover,
               book.IsDeleted,
               book.CreatedAt,
               book.UpdatedAt,
               userBookReviewsModel);
        }

        bookDetailsViewModel = new BookDetailsViewModel(
                 book.Id,
                 book.Title,
                 book.Description,
                 book.ISBN,
                 book.IdAuthor,
                 book.Author!.Name.FullName,
                 book.Publisher,
                 book.IdGenre,
                 book.Genre!.Description,
                 book.PublishedYear,
                 book.PageAmount,
                 book.AverageRating,
                 book.BookCover,
                 book.IsDeleted,
                 book.CreatedAt,
                 book.UpdatedAt,
                 new List<UserBookViewModel>());

        return Result.Ok(bookDetailsViewModel);

    }
}
