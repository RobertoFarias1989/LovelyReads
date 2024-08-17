using LovelyReads.Core.Results;
using MediatR;

namespace LovelyReads.Application.Genre.Commands.CreateGenre;

public class CreateGenreCommand : IRequest<Result<int>>
{
    public string? Description { get;  set; }
}
