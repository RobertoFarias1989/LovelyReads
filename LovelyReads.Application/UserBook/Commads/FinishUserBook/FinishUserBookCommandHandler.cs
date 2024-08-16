using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.UserBook.Commads.FinishUserBook;

public class FinishUserBookCommandHandler : IRequestHandler<FinishUserBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public FinishUserBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(FinishUserBookCommand request, CancellationToken cancellationToken)
    {
        var userBook = await _unitOfWork.UserBookRepository.GetByIdAsync(request.Id);

        if (userBook != null && userBook.IsDeleted != true)
        {
            userBook.FinishRead();

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            return Result.Fail(UserBookErrors.NotFound);            
        }

        return Result.Ok();
    }
}
