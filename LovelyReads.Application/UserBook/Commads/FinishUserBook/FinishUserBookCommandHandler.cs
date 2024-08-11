using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.FinishUserBook;

public class FinishUserBookCommandHandler : IRequestHandler<FinishUserBookCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public FinishUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(FinishUserBookCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.Id);

        if (userBook != null && userBook.IsDeleted != true)
        {
            userBook.FinishRead();

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("The UserBook was not found or it's already deleted.");
        }

        return Unit.Value;
    }
}
