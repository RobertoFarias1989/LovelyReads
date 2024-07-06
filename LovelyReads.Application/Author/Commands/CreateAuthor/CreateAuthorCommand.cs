using MediatR;

namespace LovelyReads.Application.Author.Commands.CreateAuthor;

public class CreateAuthorCommand : IRequest<int>
{
    public string Born { get;  set; }
    public string? Died { get;  set; }
    public string Description { get;  set; }
    public string FullName { get;  set; }
    public byte Image { get;  set; }
}
