using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Application.BookReview.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetDetailsByIdAsync(request.Id);

        if (book == null) 
            throw new Exception("The book was not found.");

        var bookReviewsModel = book.reviews!
            .Where(br => br.IdBook == request.Id)
            .Select(br => new BookReviewViewModel(
                br.Id,
                br.Rating,
                br.Comment,
                br.IdUser,
                br.IdBook)).ToList();

        var bookDetailsViewModel = new BookDetailsViewModel(
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
            bookReviewsModel);

        return bookDetailsViewModel;

    }
}
