using MediatR;

namespace LovelyReads.Application.BookReview.Commands.CreateBookReview
{
    public class CreateBookReviewCommand : IRequest<int>
    {    
        public byte Rating { get;  set; }
        public string? Comment { get;  set; }
        public int IdUser { get;  set; }
        public int IdBook { get;  set; }
    }
}
