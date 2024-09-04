using LovelyReads.Application.Author.ViewModels;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAllAuthors;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, PaginationResult<AuthorViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAuthorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResult<AuthorViewModel>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var paginationAuthor = await _unitOfWork.AuthorRepository.GetAllAsync(request.Query, request.Page);

        var authorViewModel = paginationAuthor
            .Data
            .Where(entity => entity.IsDeleted == false)
            .Select(a => new AuthorViewModel(a.Id, a.Description, a.Name.FullName, a.Image))
            .ToList();

        var paginationAuthorViewModel = new PaginationResult<AuthorViewModel>(
            paginationAuthor.Page,
            paginationAuthor.TotalPages,
            paginationAuthor.PageSize,
            paginationAuthor.ItemsCount,
            authorViewModel);

        return paginationAuthorViewModel;

    }
}
