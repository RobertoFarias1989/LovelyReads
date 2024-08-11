using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetAllGenre;

public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<GenreViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGenresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GenreViewModel>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetAllAsync();

        var genreViewModel = genre
            .Where(entity => entity.IsDeleted == false)
            .Select(g => new GenreViewModel(
                g.Id,
                g.Description,
                g.IsDeleted,
                g.CreatedAt,
                g.UpdatedAt))
            .ToList();

        return genreViewModel;
    }
}
