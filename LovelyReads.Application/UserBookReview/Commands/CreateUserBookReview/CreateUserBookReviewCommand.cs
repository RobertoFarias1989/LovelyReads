using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.CreateBookReview;

public class CreateUserBookReviewCommand : IRequest<Result<int>>
{    
    public byte Rating { get;  set; }
    public string? Comment { get;  set; }
    public int IdUser { get;  set; }
    public int IdBook { get;  set; }
}
