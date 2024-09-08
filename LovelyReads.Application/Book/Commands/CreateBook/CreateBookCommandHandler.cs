using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.Book.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookCoverPath = Path.Combine("BookStorage", request.BookCover!.FileName);

            //Comentar estas linhas quando do teste unitário
            //using Stream fileStream = new FileStream(bookCoverPath, FileMode.Create);
            //request.BookCover.CopyTo(fileStream);

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

            await _unitOfWork.CompleteAsync();

            return Result.Ok(book.Id);
        }
    }
}
