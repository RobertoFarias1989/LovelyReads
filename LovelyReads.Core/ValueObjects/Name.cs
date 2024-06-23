namespace LovelyReads.Core.ValueObjects;

public record Name
{
    public Name(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; init; }
}
