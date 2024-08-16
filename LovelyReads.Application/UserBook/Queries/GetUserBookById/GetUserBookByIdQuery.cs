using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetUserBookById;

public class GetUserBookByIdQuery : IRequest<Result<UserBookDetailsViewModel>>
{
    public GetUserBookByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
