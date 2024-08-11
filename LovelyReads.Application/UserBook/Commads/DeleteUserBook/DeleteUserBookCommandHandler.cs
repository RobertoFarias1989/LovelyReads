using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.DeleteUserBook;

public class DeleteUserBookCommandHandler : IRequestHandler<DeleteUserBookCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUserBookCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.Id);

        if(userBook != null && userBook.IsDeleted != true)
        {
            userBook.Delete();

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("The UserBook was not found or it's already deleted.");
        }

        return Unit.Value;
    }
}
