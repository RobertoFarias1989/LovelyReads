using MediatR;

namespace LovelyReads.Application.UserBook.Commads.FinishUserBook;

public class FinishUserBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
