using LovelyReads.Application.UserBookReview.ViewModels;
using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;
using LovelyReads.Core.Results;
using LovelyReads.Core.Errors;

namespace LovelyReads.Application.UserBook.Queries.GetUserBookById;

public class GetUserBookByIdQueryHandler : IRequestHandler<GetUserBookByIdQuery, Result<UserBookDetailsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserBookByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UserBookDetailsViewModel>> Handle(GetUserBookByIdQuery request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetDetailsByIdAsync(request.Id);
        UserBookDetailsViewModel userBookDetailsViewModel;

        if (userBook == null)
            return Result.Fail<UserBookDetailsViewModel>(UserBookErrors.NotFound);
            

        if(userBook.Reviews!.Count > 0)
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
                userBook.User!.Name.FullName,
                userBook.IdBook,
                userBook.Book!.Title,
                userBook.StartToReadAt,
                userBook.FinishReadAt,
                userBook.PageAmountReaded,
                userBook.PageAmountToFinishRead,
                userBook.IsDeleted,
                userBook.CreatedAt,
                userBook.UpdatedAt,
                reviews);
        }

        userBookDetailsViewModel = new UserBookDetailsViewModel(
               userBook.Id,
               userBook.IdUser,
               userBook.User!.Name.FullName,
               userBook.IdBook,
               userBook.Book!.Title,
               userBook.StartToReadAt,
               userBook.FinishReadAt,
               userBook.PageAmountReaded,
               userBook.PageAmountToFinishRead,
               userBook.IsDeleted,
               userBook.CreatedAt,
               userBook.UpdatedAt,
               new List<UserBookReviewViewModel>());

        return Result.Ok(userBookDetailsViewModel);

    }
}
