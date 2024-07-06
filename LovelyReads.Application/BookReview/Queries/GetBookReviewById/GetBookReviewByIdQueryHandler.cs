using LovelyReads.Application.BookReview.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.BookReview.Queries.GetBookReviewById;

public class GetBookReviewByIdQueryHandler : IRequestHandler<GetBookReviewByIdQuery, BookReviewDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookReviewByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BookReviewDetailsViewModel> Handle(GetBookReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var bookReview = await _unitOfWork.BookReviewRepository.GetDetailsByIdAsync(request.Id);

        if(bookReview != null)
        {
            var bookReviewDetailsViewModel = new BookReviewDetailsViewModel(bookReview.Id,
                bookReview.Rating,
                bookReview.Comment,
                bookReview.IdUser,
                bookReview.IdBook,
                bookReview.User!.Name.FullName,
                bookReview.Book!.Title);

            return bookReviewDetailsViewModel;
        }
        else
        {
            throw new Exception($"The BookReview with Id:{request.Id} was not found.");
        }
    }
}
