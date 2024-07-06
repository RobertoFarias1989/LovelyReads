using LovelyReads.Application.Author.ViewModels;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQuery : IRequest<AuthorDetailsViewModel>
{
    public GetAuthorByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
