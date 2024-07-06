using LovelyReads.Application.BookReview.ViewModels;
using MediatR;

namespace LovelyReads.Application.BookReview.Queries.GetAllBookReviews;

public class GetAllBookReviewsQuery : IRequest<List<BookReviewViewModel>>
{
}
