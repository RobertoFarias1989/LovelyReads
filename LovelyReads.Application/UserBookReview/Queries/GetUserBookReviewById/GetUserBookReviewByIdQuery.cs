using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetBookReviewById;

public class GetUserBookReviewByIdQuery : IRequest<Result<UserBookReviewDetailsViewModel>>
{
    public GetUserBookReviewByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
