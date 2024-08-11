using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBooksQueryHandler : IRequestHandler<GetAllUserBooksQuery, List<UserBookViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserBooksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserBookViewModel>> Handle(GetAllUserBooksQuery request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetAllAsync();

        var userBookViewModel = userBook
            .Where(entity => entity.IsDeleted == false)
            .Select(u => new UserBookViewModel(u.Id, u.IdUser, u.IdBook)).ToList();

        return userBookViewModel;
    }
}
