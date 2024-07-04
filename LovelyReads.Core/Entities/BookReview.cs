namespace LovelyReads.Core.Entities;

public class BookReview : BaseEntity
{
    public BookReview(byte rating, string comment, int idUser, int idBook)
    {
        Rating = rating;
        Comment = comment;
        IdUser = idUser;
        IdBook = idBook;

        UpdatedAt = null;
        IsActive = true;
    }

    public byte Rating { get; private set; }
    public string Comment { get; private set; }
    public int IdUser { get; private set; }
    public User? User { get; private set; }
    public int IdBook { get; private set; }
    public Book?  Book { get; private set; }
}
