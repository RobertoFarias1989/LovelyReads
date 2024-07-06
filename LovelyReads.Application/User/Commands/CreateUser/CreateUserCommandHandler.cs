using LovelyReads.Core.Repositories;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Core.Entities.User(
            new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!),
            new CPF(request.CPFNumber!),
            new Email(request.EmailAddress!),
            new Name(request.FullName!),
            new Password(request.PasswordValue!));

        await _unitOfWork.UserRepository.AddAsync(user);

        await _unitOfWork.CompleteAsync();

        return user.Id;
    }
}
