using LovelyReads.Application.Author.ViewModels;
using LovelyReads.Core.Models;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAllAuthors;

public class GetAllAuthorsQuery : IRequest<PaginationResult<AuthorViewModel>>
{
    public GetAllAuthorsQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get; set; }
    public int Page { get; set; }
}
