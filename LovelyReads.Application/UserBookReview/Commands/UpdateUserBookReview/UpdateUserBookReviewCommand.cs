using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.UpdateBookReview;

public class UpdateUserBookReviewCommand : IRequest<Result>
{
    public int Id { get; set; }
    public byte Rating { get;  set; }
    public string? Comment { get;  set; }
}
