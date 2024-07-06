using LovelyReads.Application.Genre.ViewModels;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetAllGenre;

public class GetAllGenreQuery : IRequest<List<GenreViewModel>>
{
}
