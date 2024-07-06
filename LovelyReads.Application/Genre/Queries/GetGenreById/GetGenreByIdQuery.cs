using LovelyReads.Application.Genre.ViewModels;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetGenreById;

public class GetGenreByIdQuery : IRequest<GenreDetailsViewModel>
{
    public GetGenreByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
