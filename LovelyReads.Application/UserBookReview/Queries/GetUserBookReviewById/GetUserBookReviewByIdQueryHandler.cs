using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBookReview.Queries.GetBookReviewById;

public class GetUserBookReviewByIdQueryHandler : IRequestHandler<GetUserBookReviewByIdQuery, UserBookReviewDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserBookReviewByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserBookReviewDetailsViewModel> Handle(GetUserBookReviewByIdQuery request, CancellationToken cancellationToken)
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

            return bookReviewDetailsViewModel;
        }
        else
        {
            throw new Exception($"The BookReview with Id:{request.Id} was not found.");
        }
    }
}
