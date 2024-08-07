﻿using LovelyReads.Application.User.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly IUnitOfWork? _unitOfWork;
    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork!.UserRepository.GetAllAsync();

        var userViewModel = users
            .Select(u => new UserViewModel(
                u.Address.Street,
                u.Address.City,
                u.Address.State,
                u.Address.PostalCode,
                u.Address.Country,
                u.CPF.CPFNumber,
                u.Email.EmailAddress,
                u.Name.FullName,
                u.Password.PasswordValue))
            .ToList();

        return userViewModel;
    }
}
