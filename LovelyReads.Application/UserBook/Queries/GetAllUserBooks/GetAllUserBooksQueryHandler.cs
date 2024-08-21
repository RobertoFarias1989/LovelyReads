using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.DTOs;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBooksQueryHandler : IRequestHandler<GetAllUserBooksQuery, List<UserBookDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserBooksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserBookDTO>> Handle(GetAllUserBooksQuery request, CancellationToken cancellationToken)
    {
        //var userBook = await _unitOfWork.UserBookRepository.GetAllAsync();

        //var userBookViewModel = userBook
        //    .Where(entity => entity.IsDeleted == false)
        //    .Select(u => new UserBookViewModel(u.Id, u.IdUser, u.IdBook)).ToList();

        //return userBookViewModel;

        return await _unitOfWork.UserBookRepository.GetAllBooksReadedAsync();
    }
}
