using LovelyReads.Application.Book.ViewModels;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
    }
}
