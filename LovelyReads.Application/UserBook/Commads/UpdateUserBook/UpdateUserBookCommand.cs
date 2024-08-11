using MediatR;

namespace LovelyReads.Application.UserBook.Commads.UpdateUserBook;

public class UpdateUserBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
