using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBookQueryHandler : IRequestHandler<GetAllUserBookQuery, List<UserBookViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserBookQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserBookViewModel>> Handle(GetAllUserBookQuery request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetAllAsync();

        var userBookViewModel = userBook
            .Select(u => new UserBookViewModel(u.Id, u.IdUser, u.IdBook)).ToList();

        return userBookViewModel;
    }
}
