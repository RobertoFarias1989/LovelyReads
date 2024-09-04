using LovelyReads.Application.User.ViewModels;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginationResult<UserViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var paginationUsers = await _unitOfWork!.UserRepository.GetAllAsync(request.Query, request.Page);

        var userViewModel = paginationUsers
            .Data
            .Where(entity => entity.IsDeleted == false)
            .Select(u => new UserViewModel(
                u.Id,
                u.Address.Street,
                u.Address.City,
                u.Address.State,
                u.Address.PostalCode,
                u.Address.Country,
                u.CPF.CPFNumber,
                u.Email.EmailAddress,
                u.Name.FullName,
                u.Password.PasswordValue,
                u.Role))
            .ToList();

        var paginationUsersViewModel = new PaginationResult<UserViewModel>(
            paginationUsers.Page,
            paginationUsers.TotalPages,
            paginationUsers.PageSize,
            paginationUsers.ItemsCount,
            userViewModel);

        return paginationUsersViewModel;
    }
}
