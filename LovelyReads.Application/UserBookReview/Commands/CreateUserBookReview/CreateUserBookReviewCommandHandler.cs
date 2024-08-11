using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Commands.CreateBookReview;

public class CreateUserBookReviewCommandHandler : IRequestHandler<CreateUserBookReviewCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserBookReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserBookReviewCommand request, CancellationToken cancellationToken)
    {

        var bookReview = new Core.Entities.UserBookReview(
            request.Rating, request.Comment!, request.IdUser, request.IdBook);

        await _unitOfWork.UserBookReviewRepository.AddAsync(bookReview);

        await _unitOfWork.CompleteAsync();

        return bookReview.Id;

    }
}
