using LovelyReads.Application.User.ViewModels;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
