namespace LovelyReads.Core.ValueObjects;

public record Email
{
    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string EmailAddress { get; init; }
}
