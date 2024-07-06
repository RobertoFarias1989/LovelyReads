using MediatR;

namespace LovelyReads.Application.BookReview.Commands.DeleteBookReview
{
    public class DeleteBookReviewCommand : IRequest<Unit>
    {
        public DeleteBookReviewCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
