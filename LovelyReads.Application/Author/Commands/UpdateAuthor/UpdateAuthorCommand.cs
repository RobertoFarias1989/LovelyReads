using MediatR;

namespace LovelyReads.Application.Author.Commands.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<Unit>
{
    public int Id { get;  set; }
    public string Born { get; set; }
    public string? Died { get; set; }
    public string Description { get; set; }
    public string FullName { get; set; }
    public byte Image { get;  set; }
}
