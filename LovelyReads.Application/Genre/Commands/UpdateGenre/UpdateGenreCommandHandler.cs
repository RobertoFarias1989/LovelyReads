using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.UpdateGenre;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(request.Id);

        if (genre is not null)
        {
            genre.Update(request.Description!);      

            await _unitOfWork.CompleteAsync();
        }
        else
        {
            return Result.Fail(GenreErrors.NotFound);            
        }

        return Result.Ok();
    }
}
