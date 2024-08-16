using LovelyReads.Core.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LovelyReads.Application.Author.Commands.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<Result>
{
    public int Id { get;  set; }
    public string? Born { get; set; }
    public string? Died { get; set; }
    public string? Description { get; set; }
    public string? FullName { get; set; }
    public IFormFile? Image { get;  set; }
}
