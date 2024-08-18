using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.CreateUserBook;

public class CreateUserBookCommand : IRequest<Result<int>>
{
    public int IdUser { get;  set; }
    public int IdBook { get;  set; }
    //public short PageAmountToFinishRead { get;  set; }
}
