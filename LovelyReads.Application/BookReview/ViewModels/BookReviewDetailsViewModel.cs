namespace LovelyReads.Application.BookReview.ViewModels;

public class BookReviewDetailsViewModel
{
    public BookReviewDetailsViewModel(int id, byte rating, string? comment, int idUser, int idBook, string userFullName, string bookTitle)
    {
        Id = id;
        Rating = rating;
        Comment = comment;
        IdUser = idUser;
        IdBook = idBook;
        UserFullName = userFullName;
        BookTitle = bookTitle;
    }

    public int Id { get; private set; }
    public byte Rating { get; private set; }
    public string? Comment { get; private set; }
    public int IdUser { get; private set; }
    public int IdBook { get; private set; }
    public string UserFullName { get; private set; }
    public string BookTitle { get; private set; }
}
