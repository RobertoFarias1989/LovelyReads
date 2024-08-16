using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.UpdateBookReview;

public class UpdateUserBookReviewCommandHandler : IRequestHandler<UpdateUserBookReviewCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserBookReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserBookReviewCommand request, CancellationToken cancellationToken)
    {
        var bookReview = await _unitOfWork.UserBookReviewRepository.GetByIdAsync(request.Id);

        if(bookReview != null && bookReview.IsDeleted != true)
        {

            bookReview.Update(request.Rating, request.Comment!);     

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            return Result.Fail(UserBookReviewErrors.NotFound);           
        }

        return Result.Ok();
    }
}
