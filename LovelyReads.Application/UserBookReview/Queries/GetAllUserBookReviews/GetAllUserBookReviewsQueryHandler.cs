using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetAllBookReviews;

public class GetAllUserBookReviewsQueryHandler : IRequestHandler<GetAllUserBookReviewsQuery, PaginationResult<UserBookReviewViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserBookReviewsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<UserBookReviewViewModel>> Handle(GetAllUserBookReviewsQuery request, CancellationToken cancellationToken)
    {
        var paginationBookReviews = await _unitOfWork.UserBookReviewRepository.GetAllAsync(request.Query, request.Page);

        var bookReviewsModel = paginationBookReviews
            .Data
            .Where(entity => entity.IsDeleted == false)
            .Select(br => new UserBookReviewViewModel(br.Id, br.Rating, br.Comment, br.IdUser, br.IdUserBook))
            .ToList();

        var paginationBookReviewsViewModel = new PaginationResult<UserBookReviewViewModel>(
            paginationBookReviews.Page,
            paginationBookReviews.TotalPages,
            paginationBookReviews.PageSize,
            paginationBookReviews.ItemsCount,
            bookReviewsModel);

        return paginationBookReviewsViewModel;
    }
}
