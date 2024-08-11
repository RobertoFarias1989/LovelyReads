using MediatR;

namespace LovelyReads.Application.UserBook.Commads.DeleteUserBook;

public class DeleteUserBookCommand : IRequest<Unit>
{
    public DeleteUserBookCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
