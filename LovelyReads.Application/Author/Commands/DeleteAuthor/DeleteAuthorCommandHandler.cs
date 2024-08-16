using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Author.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id);

        if (author != null && author.IsDeleted != true)
        {
            author.Delete();   

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            return Result.Fail(AuthorErrors.NotFound);           
        }

        return Result.Ok();

    }
}
