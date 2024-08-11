using LovelyReads.Application.UserBook.ViewModels;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBooksQuery : IRequest<List<UserBookViewModel>>
{

}
