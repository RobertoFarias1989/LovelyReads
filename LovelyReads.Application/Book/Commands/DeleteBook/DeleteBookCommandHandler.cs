using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Book.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

            if(book is not null && book.IsActive == true)
            {
                book.Inactived();

                _unitOfWork.BookRepository.UpdateAsync(book);

                await _unitOfWork.CompleteAsync();
            }
            else
            {
                throw new Exception("The book was not found or it's already inatived.");
            }

            return Unit.Value;
        }
    }
}
