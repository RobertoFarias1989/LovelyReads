using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.UpdateUserBook;

public class UpdateUserBookCommand : IRequest<Result>
{
    public int Id { get; set; }
}
