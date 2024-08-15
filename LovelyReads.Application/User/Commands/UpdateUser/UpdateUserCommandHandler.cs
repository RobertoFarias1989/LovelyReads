using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user != null && user.IsDeleted != true)
        {
            user.Update(
                new Address(request.Street!, request.City!, request.State!, request.PostalCode!, request.Country!),
                new CPF(request.CPFNumber!),
                new Email(request.EmailAddress!),
                new Name(request.FullName!),
                new Password(request.PasswordValue!));     

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            return Result.Fail(UserErrors.NotFound);            
        }

        return Result.Ok();
    }
}
