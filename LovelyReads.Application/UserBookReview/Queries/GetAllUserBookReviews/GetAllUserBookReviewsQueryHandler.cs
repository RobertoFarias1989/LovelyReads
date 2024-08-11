using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetAllBookReviews;

public class GetAllUserBookReviewsQueryHandler : IRequestHandler<GetAllUserBookReviewsQuery, List<UserBookReviewViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserBookReviewsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserBookReviewViewModel>> Handle(GetAllUserBookReviewsQuery request, CancellationToken cancellationToken)
    {
        var bookReviews = await _unitOfWork.UserBookReviewRepository.GetAllAsync();

        var bookReviewsModel = bookReviews
            .Select(br => new UserBookReviewViewModel(br.Id, br.Rating, br.Comment, br.IdUser, br.IdUserBook))
            .ToList();

        return bookReviewsModel!;
    }
}
