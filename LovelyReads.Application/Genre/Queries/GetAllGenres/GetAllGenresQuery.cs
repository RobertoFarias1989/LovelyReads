using LovelyReads.Application.Genre.ViewModels;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetAllGenre;

public class GetAllGenresQuery : IRequest<List<GenreViewModel>>
{
}
