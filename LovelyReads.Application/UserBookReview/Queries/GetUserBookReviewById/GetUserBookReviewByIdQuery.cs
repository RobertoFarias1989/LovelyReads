using LovelyReads.Application.UserBookReview.ViewModels;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetBookReviewById;

public class GetUserBookReviewByIdQuery : IRequest<UserBookReviewDetailsViewModel>
{
    public GetUserBookReviewByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
