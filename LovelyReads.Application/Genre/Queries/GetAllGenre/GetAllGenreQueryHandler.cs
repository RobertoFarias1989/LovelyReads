using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetAllGenre;

public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQuery, List<GenreViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGenreQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GenreViewModel>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetAllAsync();

        var genreViewModel = genre
            .Select(g => new GenreViewModel(
                g.Id,
                g.Description,
                g.IsActive,
                g.CreatedAt,
                g.UpdatedAt))
            .ToList();

        return genreViewModel;
    }
}
