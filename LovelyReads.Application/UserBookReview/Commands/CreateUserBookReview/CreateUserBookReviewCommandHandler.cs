using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.CreateBookReview;

public class CreateUserBookReviewCommandHandler : IRequestHandler<CreateUserBookReviewCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserBookReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateUserBookReviewCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.IdBook);

        var userBookResult = userBook!.CheckFinishReadDate(userBook.FinishReadAt);

        if (!userBookResult.Success)
            return Result.Fail<int>(userBookResult.Errors);

        var bookReview = new Core.Entities.UserBookReview(
            request.Rating, request.Comment!, request.IdUser, request.IdBook);

        await _unitOfWork.UserBookReviewRepository.AddAsync(bookReview);

        await _unitOfWork.CompleteAsync();

        return Result.Ok(bookReview.Id);

    }
}
