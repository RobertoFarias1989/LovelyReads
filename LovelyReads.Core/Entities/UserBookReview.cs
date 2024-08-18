using LovelyReads.Core.Errors;
using LovelyReads.Core.Results;

namespace LovelyReads.Core.Entities;

public class UserBookReview : BaseEntity
{
    public UserBookReview()
    {
        
    }
    public UserBookReview(byte rating, string comment, int idUser, int idUserBook)
    {
        Rating = rating;
        Comment = comment;
        IdUser = idUser;
        IdUserBook = idUserBook;

        CreatedAt = DateTime.Now;
        UpdatedAt = null;
        IsDeleted = false;
    }

    public byte Rating { get; private set; }
    public string Comment { get; private set; }
    public int IdUser { get; private set; }
    public User? User { get; private set; }
    public int IdUserBook { get; private set; }
    public UserBook? UserBook { get; private set; }

    public void Update(byte rating, string comment)
    {
        Rating = rating;
        Comment = comment;

        UpdatedAt = DateTime.Now;
    }
    
}
