using LovelyReads.Application.UserBookReview.ViewModels;

namespace LovelyReads.Application.UserBook.ViewModels;

public class UserBookDetailsViewModel
{
    public UserBookDetailsViewModel(int id,
        int idUser,
        string userName,
        int idBook,
        string bookTitle,
        DateTime startToReadAt,
        DateTime? finishReadAt,
        short pageAmountReaded,
        short pageAmountToFinishRead, bool isDeleted, DateTime createdAt, DateTime? updatedAt, List<UserBookReviewViewModel> reviews)
    {
        Id = id;
        IdUser = idUser;
        UserName = userName;
        IdBook = idBook;
        BookTitle = bookTitle;
        StartToReadAt = startToReadAt;
        FinishReadAt = finishReadAt;
        PageAmountReaded = pageAmountReaded;
        PageAmountToFinishRead = pageAmountToFinishRead;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Reviews = reviews;
    }

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public string UserName { get; private set; }
    public int IdBook { get; private set; }
    public string BookTitle { get; private set; }
    public DateTime StartToReadAt { get; private set; }
    public DateTime? FinishReadAt { get; private set; }
    public short PageAmountReaded { get; private set; }
    public short PageAmountToFinishRead { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<UserBookReviewViewModel> Reviews { get; private set; }
}
