using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.DeleteUserBook;

public class DeleteUserBookCommand : IRequest<Result>
{
    public DeleteUserBookCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
