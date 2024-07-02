using MediatR;

namespace LovelyReads.Application.Author.Commands.DeleteAuthor;

public class DeleteAuthorCommand : IRequest<Unit>
{
    public DeleteAuthorCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
