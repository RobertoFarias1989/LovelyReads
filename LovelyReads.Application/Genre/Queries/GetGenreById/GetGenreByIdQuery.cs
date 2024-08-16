using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetGenreById;

public class GetGenreByIdQuery : IRequest<Result<GenreDetailsViewModel>>
{
    public GetGenreByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
