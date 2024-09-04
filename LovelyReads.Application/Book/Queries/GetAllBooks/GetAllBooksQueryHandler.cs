using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, PaginationResult<BookViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResult<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var paginationBooks = await _unitOfWork.BookRepository.GetAllAsync(request.Query, request.Page);

            var booksViewModel = paginationBooks
                .Data
                .Where(entity => entity.IsDeleted == false)
                .Select(b => new BookViewModel(
                    b.Id,
                    b.Title,
                    b.PublishedYear,
                    b.AverageRating,
                    b.BookCover))
                .ToList();

            var paginationBooksViewModel = new PaginationResult<BookViewModel>(
                paginationBooks.Page,
                paginationBooks.TotalPages,
                paginationBooks.PageSize,
                paginationBooks.ItemsCount,
                booksViewModel);

            return paginationBooksViewModel;
        }
    }
}
