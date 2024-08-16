namespace LovelyReads.Core.Errors;

public interface IError
{
    public string Code { get; init; }
    public string Message { get; init; }
}
