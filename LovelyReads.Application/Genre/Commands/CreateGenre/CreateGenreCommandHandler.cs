using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.CreateGenre;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = new Core.Entities.Genre(request.Description!);

        await _unitOfWork.GenreRepository.AddAsync(genre);

        await _unitOfWork.CompleteAsync();

        return Result.Ok(genre.Id);
    }
}
