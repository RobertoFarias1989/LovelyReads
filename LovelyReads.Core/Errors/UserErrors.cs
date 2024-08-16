namespace LovelyReads.Core.Errors;

public static class UserErrors
{
    public static readonly Error NotFound = new(
           "User.NotFound", "The User could not be found");

    public static readonly Error AlreadyDeleted = new(
            "User.AlreadyDeleted", "The User is already deleted.");
}
