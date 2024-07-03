using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Book.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Core.Entities.Book(request.Title,
                request.Description,
                request.ISBN,
                request.IdAuthor,
                request.Publisher,
                request.IdGenre,
                request.PublishedYear,
                request.PageAmount,
                request.AverageRating,
                request.BookCover);

            await _unitOfWork.BookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
