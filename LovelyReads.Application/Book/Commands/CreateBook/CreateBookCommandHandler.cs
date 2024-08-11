using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.ValueObjects;
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
            var bookCoverPath = Path.Combine("BookStorage", request.BookCover!.FileName);
            using Stream fileStream = new FileStream(bookCoverPath, FileMode.Create);
            request.BookCover.CopyTo(fileStream);

            var book = new Core.Entities.Book(request.Title!,
                request.Description!,
                new Edition(request.EditionNumber, request.EditionDescription!),
                request.ISBN!,
                request.IdAuthor,
                request.Publisher!,
                request.IdGenre,
                request.PublishedYear,
                request.PageAmount,          
                bookCoverPath);

            await _unitOfWork.BookRepository.AddAsync(book);

            return book.Id;
        }
    }
}
