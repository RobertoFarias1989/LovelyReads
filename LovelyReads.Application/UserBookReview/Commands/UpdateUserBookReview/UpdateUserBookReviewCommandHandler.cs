using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.UpdateBookReview;

public class UpdateUserBookReviewCommandHandler : IRequestHandler<UpdateUserBookReviewCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserBookReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserBookReviewCommand request, CancellationToken cancellationToken)
    {
        var bookReview = await _unitOfWork.UserBookReviewRepository.GetByIdAsync(request.Id);

        if(bookReview != null && bookReview.IsDeleted != true)
        {

            bookReview.Update(request.Rating, request.Comment!);     

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            throw new Exception("The UserBookReview was not found or it's already inactived.");
        }

        return Unit.Value;
    }
}
