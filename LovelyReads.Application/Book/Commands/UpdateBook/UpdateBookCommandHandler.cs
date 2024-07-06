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
            book.Update(
                request.Title,
                request.Description,
                request.ISBN,
                request.IdAuthor,
                request.Publisher,
                request.IdGenre,
                request.PublishedYear,
                request.PageAmount,
                request.AverageRating,
                request.BookCover);

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
