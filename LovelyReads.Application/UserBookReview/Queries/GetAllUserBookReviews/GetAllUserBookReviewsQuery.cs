using LovelyReads.Application.UserBookReview.ViewModels;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetAllBookReviews;

public class GetAllUserBookReviewsQuery : IRequest<List<UserBookReviewViewModel>>
{
}
