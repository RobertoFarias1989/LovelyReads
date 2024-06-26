using LovelyReads.Application.Author.ViewModels;
using MediatR;

namespace LovelyReads.Application.Author.Queries.GetAllAuthors;

public class GetAllAuthorsQuery : IRequest<List<AuthorViewModel>>
{
}
