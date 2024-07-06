using LovelyReads.Application.User.ViewModels;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{
}
