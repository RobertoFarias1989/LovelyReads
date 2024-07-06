using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetGenreById;

public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDetailsViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GenreDetailsViewModel> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(request.Id);

        if(genre == null) return null;

        var books = genre.Books
            .Where(b => b.IdGenre == genre.Id)
            .Select(b => new BookViewModel(
                b.Id,
                b.Title,
                b.PublishedYear,
                b.AverageRating,
                b.BookCover)).ToList();

        var genreDetailsViewModel = new GenreDetailsViewModel(
            genre.Id,
            genre.Description,
            genre.IsActive,
            genre.CreatedAt,
            genre.UpdatedAt,
            books);

        return genreDetailsViewModel;
    }
}
