namespace LovelyReads.Application.UserBookReview.ViewModels;

public class UserBookReviewDetailsViewModel
{
    public UserBookReviewDetailsViewModel(int id,
        byte rating,
        string? comment,
        int idUser, int idBook, string userFullName, string bookTitle, bool isDeleted, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Rating = rating;
        Comment = comment;
        IdUser = idUser;
        IdBook = idBook;
        UserFullName = userFullName;
        BookTitle = bookTitle;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public int Id { get; private set; }
    public byte Rating { get; private set; }
    public string? Comment { get; private set; }
    public int IdUser { get; private set; }
    public int IdBook { get; private set; }
    public string UserFullName { get; private set; }
    public string BookTitle { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
}
