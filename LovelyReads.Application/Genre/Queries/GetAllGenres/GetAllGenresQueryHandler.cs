using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetAllGenre;

public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, PaginationResult<GenreViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGenresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<GenreViewModel>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var paginationGenre = await _unitOfWork.GenreRepository.GetAllAsync(request.Query, request.Page);

        var genreViewModel = paginationGenre
            .Data
            .Where(entity => entity.IsDeleted == false)
            .Select(g => new GenreViewModel(
                g.Id,
                g.Description,
                g.IsDeleted,
                g.CreatedAt,
                g.UpdatedAt))
            .ToList();

        var paginationGenreViewModel = new PaginationResult<GenreViewModel>(
            paginationGenre.Page,
            paginationGenre.TotalPages,
            paginationGenre.PageSize,
            paginationGenre.ItemsCount,
            genreViewModel);

        return paginationGenreViewModel;
    }
}
