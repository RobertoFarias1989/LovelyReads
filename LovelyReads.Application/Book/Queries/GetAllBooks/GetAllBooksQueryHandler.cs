using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Book.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.BookRepository.GetAllAsync();

            var booksViewModel = books
                .Where(entity => entity.IsDeleted == false)
                .Select(b => new BookViewModel(
                    b.Id,
                    b.Title,
                    b.PublishedYear,
                    b.AverageRating,
                    b.BookCover))
                .ToList();

            return booksViewModel;
        }
    }
}
