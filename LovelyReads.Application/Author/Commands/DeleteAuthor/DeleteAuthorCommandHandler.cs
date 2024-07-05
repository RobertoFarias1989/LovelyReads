using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Author.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id);

        if (author != null && author.IsActive == true)
        {
            author.Inactived();

            _unitOfWork.AuthorRepository.UpdateAsync(author);

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            throw new Exception("The author was not found or it's already inatived.");
        }

        return Unit.Value;

    }
}
