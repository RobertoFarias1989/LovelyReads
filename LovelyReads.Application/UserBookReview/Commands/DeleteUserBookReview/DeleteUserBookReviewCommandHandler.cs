using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.DeleteBookReview
{
    public class DeleteUserBookReviewCommandHandler : IRequestHandler<DeleteUserBookReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserBookReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserBookReviewCommand request, CancellationToken cancellationToken)
        {
            var bookReview = await _unitOfWork.UserBookReviewRepository.GetByIdAsync(request.Id);

            if(bookReview != null && bookReview.IsDeleted != true)
            {

                bookReview.Delete();       

                await _unitOfWork.CompleteAsync();

            }
            else
            {
                throw new Exception($"The BookReview with id: {request.Id} was not found or it's already inatived.");
            }

            return Unit.Value;
        }
    }
}
