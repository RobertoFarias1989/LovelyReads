namespace LovelyReads.Core.Entities;

public class BookReview : BaseEntity
{
    public BookReview()
    {
        
    }
    public BookReview(byte rating, string comment, int idUser, int idBookReaded)
    {
        Rating = rating;
        Comment = comment;
        IdUser = idUser;
        IdBookReaded = idBookReaded;

        UpdatedAt = null;
        IsActive = true;
    }

    public byte Rating { get; private set; }
    public string Comment { get; private set; }
    public int IdUser { get; private set; }
    public User? User { get; private set; }
    public int IdBookReaded { get; private set; }
    public BookReaded? BookReaded { get; private set; }

    public void Update(byte rating, string comment)
    {
        Rating = rating;
        Comment = comment;

        UpdatedAt = DateTime.Now;
    }
}
