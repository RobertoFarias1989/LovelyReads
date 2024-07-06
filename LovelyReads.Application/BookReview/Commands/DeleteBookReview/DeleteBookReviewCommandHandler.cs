using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.BookReview.Commands.DeleteBookReview
{
    public class DeleteBookReviewCommandHandler : IRequestHandler<DeleteBookReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBookReviewCommand request, CancellationToken cancellationToken)
        {
            var bookReview = await _unitOfWork.BookReviewRepository.GetByIdAsync(request.Id);

            if(bookReview != null && bookReview.IsActive == true)
            {

                bookReview.Inactived();

                _unitOfWork.BookReviewRepository.UpdateAsync(bookReview);

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
