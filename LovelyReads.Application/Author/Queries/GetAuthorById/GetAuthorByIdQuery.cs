using LovelyReads.Application.Author.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQuery : IRequest<Result<AuthorDetailsViewModel>>
{
    public GetAuthorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
