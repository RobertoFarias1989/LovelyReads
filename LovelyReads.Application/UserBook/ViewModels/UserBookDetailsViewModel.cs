using LovelyReads.Application.UserBookReview.ViewModels;

namespace LovelyReads.Application.UserBook.ViewModels;

public class UserBookDetailsViewModel
{
    public UserBookDetailsViewModel(int id,
        int idUser,
        int idBook,
        DateTime startToReadAt,
        DateTime? finishReadAt, short pageAmountReaded, short pageAmountToFinishRead, List<UserBookReviewViewModel> reviews)
    {
        Id = id;
        IdUser = idUser;
        IdBook = idBook;
        StartToReadAt = startToReadAt;
        FinishReadAt = finishReadAt;
        PageAmountReaded = pageAmountReaded;
        PageAmountToFinishRead = pageAmountToFinishRead;
        Reviews = reviews;
    }

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public int IdBook { get; private set; }
    public DateTime StartToReadAt { get; private set; }
    public DateTime? FinishReadAt { get; private set; }
    public short PageAmountReaded { get; private set; }
    public short PageAmountToFinishRead { get; private set; }
    public List<UserBookReviewViewModel> Reviews { get; private set; }
}
