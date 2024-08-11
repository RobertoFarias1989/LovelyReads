using LovelyReads.Application.UserBook.ViewModels;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBookQuery : IRequest<List<UserBookViewModel>>
{

}
