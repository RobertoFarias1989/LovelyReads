using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.DeleteGenre;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(request.Id);

       if(genre != null && genre.IsDeleted == false)
        {
            genre.Delete();

            _unitOfWork.GenreRepository.UpdateAsync(genre);

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("The genre is already inactived.");
        }

        return Unit.Value;

    }
}
