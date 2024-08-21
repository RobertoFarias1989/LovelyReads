using LovelyReads.Application.UserBook.ViewModels;
using LovelyReads.Core.DTOs;
using MediatR;

namespace LovelyReads.Application.UserBook.Queries.GetAllUserBook;

public class GetAllUserBooksQuery : IRequest<List<UserBookDTO>>
{

}
