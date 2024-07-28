using MediatR;

namespace LovelyReads.Application.Genre.Commands.CreateGenre;

public class CreateGenreCommand : IRequest<int>
{
    public string? Description { get;  set; }
}
