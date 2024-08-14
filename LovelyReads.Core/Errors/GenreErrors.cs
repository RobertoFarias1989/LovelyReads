namespace LovelyReads.Core.Errors;

public static class GenreErrors
{
    public static readonly Error NotFound = new(
           "Genre.NotFound", "The Genre could not be found");

    public static readonly Error AlreadyDeleted = new(
            "Genre.AlreadyDeleted", "The Genre is already deleted.");
}
