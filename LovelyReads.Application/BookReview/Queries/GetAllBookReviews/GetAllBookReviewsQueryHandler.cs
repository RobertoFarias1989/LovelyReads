using LovelyReads.Application.BookReview.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.BookReview.Queries.GetAllBookReviews;

public class GetAllBookReviewsQueryHandler : IRequestHandler<GetAllBookReviewsQuery, List<BookReviewViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBookReviewsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookReviewViewModel>> Handle(GetAllBookReviewsQuery request, CancellationToken cancellationToken)
    {
        var bookReviews = await _unitOfWork.UserBookReviewRepository.GetAllAsync();

        var bookReviewsModel = bookReviews
            .Select(br => new BookReviewViewModel(br.Id, br.Rating, br.Comment, br.IdUser, br.IdUserBook))
            .ToList();

        return bookReviewsModel!;
    }
}
