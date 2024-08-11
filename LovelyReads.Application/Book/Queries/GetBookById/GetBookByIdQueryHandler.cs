using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Application.UserBook.ViewModels;
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
        BookDetailsViewModel bookDetailsViewModel;


        if (book == null) 
            throw new Exception($"The book  with id:{request.Id} was not found.");

        if (book.UserBooks != null)
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
                 new List<UserBookViewModel>());

        return bookDetailsViewModel;

    }
}
