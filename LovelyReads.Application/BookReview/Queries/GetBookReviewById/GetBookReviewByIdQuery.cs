using LovelyReads.Application.BookReview.ViewModels;
using MediatR;

namespace LovelyReads.Application.BookReview.Queries.GetBookReviewById;

public class GetBookReviewByIdQuery : IRequest<BookReviewDetailsViewModel>
{
    public GetBookReviewByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
