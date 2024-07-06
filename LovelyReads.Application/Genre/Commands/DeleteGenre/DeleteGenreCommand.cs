using MediatR;

namespace LovelyReads.Application.Genre.Commands.DeleteGenre;

public class DeleteGenreCommand : IRequest<Unit>
{
    public DeleteGenreCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
