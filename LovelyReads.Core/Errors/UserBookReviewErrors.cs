namespace LovelyReads.Core.Errors;

public static class UserBookReviewErrors
{
    public static readonly Error NotFound = new(
         "UserBookReview.NotFound", "The UserBookReview could not be found");

    public static readonly Error AlreadyDeleted = new(
            "UserBookReview.AlreadyDeleted", "The UserBookReview is already deleted.");
}
