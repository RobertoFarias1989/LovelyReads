using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.FinishUserBook;

public class FinishUserBookCommand : IRequest<Result>
{
    public int Id { get; set; }
}
