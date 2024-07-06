using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.UpdateGenre;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(request.Id);

        if (genre is not null)
        {
            genre.Update(request.Description);

             _unitOfWork.GenreRepository.UpdateAsync(genre);

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            throw new Exception("The genre is not found.");
        }

        return Unit.Value;
    }
}
