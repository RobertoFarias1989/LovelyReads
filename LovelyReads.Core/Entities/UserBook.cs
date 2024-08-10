namespace LovelyReads.Core.Entities;

public class UserBook : BaseEntity
{
    public UserBook(int idUser, int idBook, DateTime startToReadAt, DateTime finishReadAt, short pageAmountReaded, short pageAmountToFinishRead)
    {
        IdUser = idUser;
        IdBook = idBook;
        StartToReadAt = startToReadAt;
        FinishReadAt = finishReadAt;
        PageAmountReaded = pageAmountReaded;
        PageAmountToFinishRead = pageAmountToFinishRead;

        Reviews = new List<UserBookReview>();
        IsDeleted = false;
    }

    public int IdUser { get; private set; }
    public User? User { get; private set; }
    public int IdBook { get; private set; }
    public Book? Book { get; private set; }
    public DateTime StartToReadAt { get; private set; }
    public DateTime FinishReadAt { get; private set; }
    public short PageAmountReaded { get; private set; }
    public short PageAmountToFinishRead { get; private set; }
    public List<UserBookReview>? Reviews { get; private set; }

}
