using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.DTOs;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBooksQuery : IRequest<List<UserBookDTO>>
{
    public GetAllUserBooksQuery(DateTime? startToReadAt, DateTime? finishReadAt)
    {
        StartToReadAt = startToReadAt;
        FinishReadAt = finishReadAt;
    }

    public DateTime? StartToReadAt { get; private set; }
    public DateTime? FinishReadAt { get; private set; }
}
