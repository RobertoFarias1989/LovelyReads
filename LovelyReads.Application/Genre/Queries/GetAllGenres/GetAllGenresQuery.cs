using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Models;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetAllGenre;

public class GetAllGenresQuery : IRequest<PaginationResult<GenreViewModel>>
{
    public GetAllGenresQuery(string query, int page)
    {
        Query = query;
        Page = page;
    }

    public string Query { get; set; }
    public int Page { get; set; }
}
