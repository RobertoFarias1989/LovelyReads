using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.UpdateUserBook;

public class UpdateUserBookCommandHandler : IRequestHandler<UpdateUserBookCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserBookCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.Id);

        if (userBook != null && userBook.IsDeleted != true)
        {
            userBook.UpdatePageAmountReaded();

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("The UserBook was not found or it's already deleted.");
        }

        return Unit.Value;
    }
}
