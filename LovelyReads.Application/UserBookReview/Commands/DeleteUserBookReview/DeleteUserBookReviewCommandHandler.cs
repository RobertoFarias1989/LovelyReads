using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.DeleteBookReview
{
    public class DeleteUserBookReviewCommandHandler : IRequestHandler<DeleteUserBookReviewCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserBookReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteUserBookReviewCommand request, CancellationToken cancellationToken)
        {
            var bookReview = await _unitOfWork.UserBookReviewRepository.GetByIdAsync(request.Id);

            if(bookReview != null && bookReview.IsDeleted != true)
            {

                bookReview.Delete();       

                await _unitOfWork.CompleteAsync();

            }
            else
            {
                return Result.Fail(UserBookReviewErrors.NotFound);               
            }

            return Result.Ok();
        }
    }
}
