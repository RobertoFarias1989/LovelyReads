using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Core.Models;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<PaginationResult<BookViewModel>>
    {
        public GetAllBooksQuery(string query, int page)
        {
            Query = query;
            Page = page;
        }

        public string Query { get; set; }
        public int Page { get; set; }
    }
}
