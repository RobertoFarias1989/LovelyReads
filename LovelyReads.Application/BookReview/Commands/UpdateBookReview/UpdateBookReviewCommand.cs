using MediatR;

namespace LovelyReads.Application.BookReview.Commands.UpdateBookReview;

public class UpdateBookReviewCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public byte Rating { get;  set; }
    public string? Comment { get;  set; }
}
