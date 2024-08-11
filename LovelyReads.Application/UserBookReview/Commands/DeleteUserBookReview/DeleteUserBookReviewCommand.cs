using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.DeleteBookReview
{
    public class DeleteUserBookReviewCommand : IRequest<Unit>
    {
        public DeleteUserBookReviewCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
