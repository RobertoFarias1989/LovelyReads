using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.Services;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var passwordHash = _authService.ComputeSha256Hash(request.PasswordValue!);

        var user = new Core.Entities.User(
            new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!),
            new CPF(request.CPFNumber!),
            new Email(request.EmailAddress!),
            new Name(request.FullName!),
            new Password(passwordHash),
            request.Role!);

        await _unitOfWork.UserRepository.AddAsync(user);

        await _unitOfWork.CompleteAsync();

        return Result.Ok(user.Id);
    }
}
