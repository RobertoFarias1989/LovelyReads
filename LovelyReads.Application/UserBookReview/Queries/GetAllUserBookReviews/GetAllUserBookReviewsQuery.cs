using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Core.Models;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetAllBookReviews;

public class GetAllUserBookReviewsQuery : IRequest<PaginationResult<UserBookReviewViewModel>>
{
    public GetAllUserBookReviewsQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get; set; }
    public int Page { get; set; }
}
