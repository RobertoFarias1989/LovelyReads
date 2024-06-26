namespace LovelyReads.Application.Author.ViewModels;

public class AuthorViewModel
{
    public AuthorViewModel(string description, string fullName, byte image)
    {
        Description = description;
        FullName = fullName;
        Image = image;
    }

    public string Description { get; private set; }
    public string FullName { get; private set; }
    public byte Image { get; private set; }
}
