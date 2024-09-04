using LovelyReads.Application.User.ViewModels;
using LovelyReads.Core.Models;
using MediatR;

namespace LovelyReads.Application.User.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<PaginationResult<UserViewModel>>
{
    public GetAllUsersQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get; set; }
    public int Page { get; set; }
}
