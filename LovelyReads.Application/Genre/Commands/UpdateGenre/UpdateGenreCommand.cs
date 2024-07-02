using MediatR;

namespace LovelyReads.Application.Genre.Commands.UpdateGenre;

public class UpdateGenreCommand : IRequest<Unit>
{
    public int Id { get;  set; }
    public string Description { get;  set; }
}
