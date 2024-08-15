using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.DeleteGenre;

public class DeleteGenreCommand : IRequest<Result>
{
    public DeleteGenreCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
