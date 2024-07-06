using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Author.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id);

        if(author is not null)
        {
            author.Update(request.Born,
                request.Died,
                request.Description,
                new Core.ValueObjects.Name(request.FullName),
                request.Image);

             _unitOfWork.AuthorRepository.UpdateAsync(author);

            await _unitOfWork.CompleteAsync();

        }
        else
        {
            throw new Exception("The author is not found.");
        }

        return Unit.Value;
    }
}
