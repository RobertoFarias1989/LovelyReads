using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using LovelyReads.Core.ValueObjects;
using MediatR;

namespace LovelyReads.Application.Book.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

        if(book != null && book.IsDeleted == false)
        {
            if (request.BookCover != null)
            {
                var olderCoverPath = book.BookCover;
                var bookCoverPath = Path.Combine("BookStorage", request.BookCover!.FileName);

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
                new Edition(request.EditionNumber, request.EditionDescription!),
                request.ISBN!,
                request.IdAuthor,
                request.Publisher!,
                request.IdGenre,
                request.PublishedYear,
                request.PageAmount);   

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            return Result.Fail(BookErrors.NotFound);
            
        }

        return Result.Ok();
    }
}
