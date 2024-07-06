using LovelyReads.Application.Book.ViewModels;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<BookDetailsViewModel>
{
    public GetBookByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
