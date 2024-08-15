using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<Result<BookDetailsViewModel>>
{
    public GetBookByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
