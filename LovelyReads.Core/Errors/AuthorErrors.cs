namespace LovelyReads.Core.Errors;

public static class AuthorErrors
{
    public static readonly Error NotFound = new(
           "Author.NotFound", "The Author could not be found");

    public static readonly Error AlreadyDeleted = new(
            "Author.AlreadyDeleted", "The Author is already deleted.");
}
