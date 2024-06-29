using LovelyReads.Application.Book.ViewModels;

namespace LovelyReads.Application.Author.ViewModels;

public class AuthorDetailsViewModel
{
    public AuthorDetailsViewModel(int id, string born, string? died, string description, string fullName, byte image, List<BookViewModel> books)
    {
        Id = id;
        Born = born;
        Died = died;
        Description = description;
        FullName = fullName;
        Image = image;
        Books = books;
    }

    public int Id { get; private set; }
    public string Born { get; private set; }
    public string? Died { get; private set; }
    public string Description { get; private set; }
    public string FullName { get; private set; }
    public byte Image { get; private set; }
    public List<BookViewModel> Books { get; private set; }
}
