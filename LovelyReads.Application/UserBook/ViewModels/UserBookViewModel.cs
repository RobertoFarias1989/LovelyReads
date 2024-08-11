namespace LovelyReads.Application.UserBook.ViewModels;

public class UserBookViewModel
{
    public UserBookViewModel(int id, int idUser, int idBook)
    {
        Id = id;
        IdUser = idUser;
        IdBook = idBook;
    }

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public int IdBook { get; private set; }
}
