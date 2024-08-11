using LovelyReads.Application.UserBook.ViewModels;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetUserBookById;

public class GetUserBookByIdQuery : IRequest<UserBookDetailsViewModel>
{
    public GetUserBookByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
