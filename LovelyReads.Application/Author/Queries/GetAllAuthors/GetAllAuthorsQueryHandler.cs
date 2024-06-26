using LovelyReads.Application.Author.ViewModels;
using LovelyReads.Core.Repositories;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAllAuthors;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAuthorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<AuthorViewModel>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.AuthorRepository.GetAllAsync();

        //var authorViewModel = 

        return null;
    }
}
