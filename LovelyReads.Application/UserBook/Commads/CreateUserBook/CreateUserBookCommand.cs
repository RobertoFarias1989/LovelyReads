using MediatR;

namespace LovelyReads.Application.UserBook.Commads.CreateUserBook;

public class CreateUserBookCommand : IRequest<int>
{
    public int IdUser { get;  set; }
    public int IdBook { get;  set; }
    public short PageAmountToFinishRead { get;  set; }
}
