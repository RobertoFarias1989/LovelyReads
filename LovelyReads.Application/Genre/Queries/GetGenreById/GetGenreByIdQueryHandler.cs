using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Application.Genre.ViewModels;
using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Queries.GetGenreById;

public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Result<GenreDetailsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GenreDetailsViewModel>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.GenreRepository.GetDetailsByIdAsync(request.Id);

        GenreDetailsViewModel genreDetailsViewModel;

        if (genre == null)
            return Result.Fail<GenreDetailsViewModel>(GenreErrors.NotFound);            

        if (genre.Books.Count > 0)
        {
             var books = genre.Books
                .Where(b => b.IdGenre == genre.Id)
                .Select(b => new BookViewModel(
                    b.Id,
                    b.Title,
                    b.PublishedYear,
                    b.AverageRating,
                    b.BookCover)).ToList();

             genreDetailsViewModel = new GenreDetailsViewModel(
                genre.Id,
                genre.Description,
                genre.IsDeleted,
                genre.CreatedAt,
                genre.UpdatedAt,
                books);
        }

        genreDetailsViewModel = new GenreDetailsViewModel(
               genre.Id,
               genre.Description,
               genre.IsDeleted,
               genre.CreatedAt,
               genre.UpdatedAt,
               new List<BookViewModel>());


        return Result.Ok(genreDetailsViewModel);
    }
}
