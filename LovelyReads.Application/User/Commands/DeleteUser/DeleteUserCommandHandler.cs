using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if(user != null && user.IsActive == true)
        {
            user.Inactived();

            _unitOfWork.UserRepository.UpdateAsync(user);

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            throw new Exception("The user was not found or it's already inactived.");
        }

        return Unit.Value;
    }
}
