using LovelyReads.Application.User.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<Result<UserDetailsViewModel>>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
