using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Book.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

        if(book != null && book.IsActive == true)
        {
            if (request.BookCover != null)
            {
                var olderCoverPath = book.BookCover;
                var bookCoverPath = Path.Combine("Storage", request.BookCover!.FileName);

                if (!string.IsNullOrEmpty(olderCoverPath) && File.Exists(olderCoverPath))  
                {
                    File.Delete(olderCoverPath);
                }

                using Stream fileStream = new FileStream(bookCoverPath, FileMode.Create);
                request.BookCover.CopyTo(fileStream);
                book.UpdateBookCover(bookCoverPath);
            }

            book.Update(
                request.Title!,
                request.Description!,
                request.ISBN!,
                request.IdAuthor,
                request.Publisher!,
                request.IdGenre,
                request.PublishedYear,
                request.PageAmount,
                request.AverageRating);

            _unitOfWork.BookRepository.UpdateAsync(book);

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("The book was not found or it's inactived.");
        }

        return Unit.Value;
    }
}
