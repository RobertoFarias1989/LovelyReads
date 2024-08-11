using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetUserBookById;

public class GetUserBookByIdQueryHandler : IRequestHandler<GetUserBookByIdQuery, UserBookDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserBookByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserBookDetailsViewModel> Handle(GetUserBookByIdQuery request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetDetailsByIdAsync(request.Id);
        UserBookDetailsViewModel userBookDetailsViewModel;

        if (userBook == null)
            throw new Exception($"The UserBook with id:{request.Id} was not found.");

        if(userBook.Reviews != null)
        {
            var reviews = userBook.Reviews
               .Where(br => br.IdUser == userBook.Id)
               .Select(br => new UserBookReviewViewModel(
                   br.Id,
                   br.Rating,
                   br.Comment,
                   br.IdUser,
                   br.IdUserBook))
               .ToList();

            userBookDetailsViewModel = new UserBookDetailsViewModel(
                userBook.Id,
                userBook.IdUser,
                userBook.IdBook,
                userBook.StartToReadAt,
                userBook.FinishReadAt,
                userBook.PageAmountReaded,
                userBook.PageAmountToFinishRead,
                reviews);
        }

        userBookDetailsViewModel = new UserBookDetailsViewModel(
               userBook.Id,
               userBook.IdUser,
               userBook.IdBook,
               userBook.StartToReadAt,
               userBook.FinishReadAt,
               userBook.PageAmountReaded,
               userBook.PageAmountToFinishRead,
               new List<UserBookReviewViewModel>());

        return userBookDetailsViewModel;

    }
}
