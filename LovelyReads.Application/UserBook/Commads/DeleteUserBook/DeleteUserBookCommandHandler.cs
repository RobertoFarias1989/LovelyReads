using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.DeleteUserBook;

public class DeleteUserBookCommandHandler : IRequestHandler<DeleteUserBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserBookCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.Id);

        if(userBook != null && userBook.IsDeleted != true)
        {
            userBook.Delete();

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            return Result.Fail(UserBookErrors.NotFound);            
        }

        return Result.Ok();
    }
}
