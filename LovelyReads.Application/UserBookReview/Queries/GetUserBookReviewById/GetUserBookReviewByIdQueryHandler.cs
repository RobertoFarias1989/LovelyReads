using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetBookReviewById;

public class GetUserBookReviewByIdQuery : IRequest<Result<UserBookReviewDetailsViewModel>>
public class GetUserBookReviewByIdQueryHandler : IRequestHandler<GetUserBookReviewByIdQuery, Result<UserBookReviewDetailsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserBookReviewByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserBookReviewDetailsViewModel>> Handle(GetUserBookReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var bookReview = await _unitOfWork.UserBookReviewRepository.GetDetailsByIdAsync(request.Id);

        if(bookReview != null)
        {
            var bookReviewDetailsViewModel = new UserBookReviewDetailsViewModel(bookReview.Id,
                bookReview.Rating,
                bookReview.Comment,
                bookReview.IdUser,
                bookReview.IdUserBook,
                bookReview.User!.Name.FullName,
                bookReview.UserBook!.Book!.Title);

            return Result.Ok(bookReviewDetailsViewModel);
        }
        else
        {
            return Result.Fail<UserBookReviewDetailsViewModel>(UserBookReviewErrors.NotFound);            
        }
    }
}
