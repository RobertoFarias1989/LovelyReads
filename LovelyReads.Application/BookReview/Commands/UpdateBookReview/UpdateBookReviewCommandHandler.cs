using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.BookReview.Commands.UpdateBookReview;

public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateBookReviewCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateBookReviewCommand request, CancellationToken cancellationToken)
    {
        var bookReview = await _unitOfWork.BookReviewRepository.GetByIdAsync(request.Id);

        if(bookReview != null && bookReview.IsActive != false)
        {

            bookReview.Update(request.Rating, request.Comment!);

            _unitOfWork.BookReviewRepository.UpdateAsync(bookReview);

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            throw new Exception("The BookReview was not found or it's already inactived.");
        }

        return Unit.Value;
    }
}
