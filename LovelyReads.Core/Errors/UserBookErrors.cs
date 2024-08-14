namespace LovelyReads.Core.Errors;

public static class UserBookErrors
{
    public static readonly Error NotFound = new(
          "UserBook.NotFound", "The UserBook could not be found");

    public static readonly Error AlreadyDeleted = new(
            "UserBook.AlreadyDeleted", "The UserBook is already deleted.");
}
