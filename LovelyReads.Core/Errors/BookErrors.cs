namespace LovelyReads.Core.Errors;

public static class BookErrors
{

    public static readonly Error NotFound = new(
           "Book.NotFound", "The Book could not be found");

    public static readonly Error AlreadyDeleted = new(
            "Book.AlreadyDeleted", "The Book is already deleted.");
}
