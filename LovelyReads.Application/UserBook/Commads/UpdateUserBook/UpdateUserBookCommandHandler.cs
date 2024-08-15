using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.UpdateUserBook;

public class UpdateUserBookCommandHandler : IRequestHandler<UpdateUserBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserBookCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.Id);

        if (userBook != null && userBook.IsDeleted != true)
        {
            userBook.UpdatePageAmountReaded();

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            return Result.Fail(UserBookErrors.NotFound);
            
        }

        return Result.Ok();
    }
}
