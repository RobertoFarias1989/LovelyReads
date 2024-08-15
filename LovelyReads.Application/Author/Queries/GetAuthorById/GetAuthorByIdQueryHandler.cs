using LovelyReads.Application.Author.ViewModels;
using LovelyReads.Application.Book.ViewModels;
using LovelyReads.Core.Errors;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Result<AuthorDetailsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AuthorDetailsViewModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(request.Id);

        AuthorDetailsViewModel authorDetailsViewModel;

        if (author == null)
            return Result.Fail<AuthorDetailsViewModel>(AuthorErrors.NotFound);      


        if (author.Books != null)
        {
            var books = author.Books
                .Where(b => b.IdAuthor == author.Id)
                .Select(b => new BookViewModel(
                    b.Id,
                    b.Title,
                    b.PublishedYear,
                    b.AverageRating,
                    b.BookCover)).ToList();

             authorDetailsViewModel = new AuthorDetailsViewModel(
                author.Id,
                author.Born,
                author.Died,
                author.Description,
                author.Name.FullName,
                author.Image,
                books);
        }

        authorDetailsViewModel = new AuthorDetailsViewModel(
              author.Id,
              author.Born,
              author.Died,
              author.Description,
              author.Name.FullName,
              author.Image,
              new List<BookViewModel>());


        return Result.Ok(authorDetailsViewModel);
    }
}
