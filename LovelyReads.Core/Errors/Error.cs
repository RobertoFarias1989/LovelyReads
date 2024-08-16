namespace LovelyReads.Core.Errors;

public record Error(string Code, string Message) : IError
{
    public static readonly Error None = new(string.Empty, string.Empty);
}
