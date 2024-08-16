using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.UpdateGenre;

public class UpdateGenreCommand : IRequest<Result>
{
    public int Id { get;  set; }
    public string? Description { get;  set; }
}
