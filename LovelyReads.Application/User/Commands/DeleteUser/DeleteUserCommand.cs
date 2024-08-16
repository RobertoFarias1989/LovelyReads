using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Result>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
