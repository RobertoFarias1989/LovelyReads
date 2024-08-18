namespace LovelyReads.Core.Errors;

public static class UserBookErrors
{
    public static readonly Error NotFound = new(
          "UserBook.NotFound", "The UserBook could not be found");

    public static readonly Error AlreadyDeleted = new(
            "UserBook.AlreadyDeleted", "The UserBook is already deleted.");

    public static readonly Error PageAmountReadedCannotBeZero = new(
            "UserBook.PageAmountReadedCannotBeZero", "The PageAmountReaded cannot be zero.");

    public static readonly Error FinishReadAtCantBeNull = new(
            "UserBook.FinishReadAtCantBeNull", "The FinishReadAt cannot be null.");
}
