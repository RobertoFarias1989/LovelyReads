namespace LovelyReads.Application.Author.ViewModels;

public class AuthorViewModel
{
    public AuthorViewModel(int id,string description, string fullName, byte image)
    {
        Id = id;
        Description = description;
        FullName = fullName;
        Image = image;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public string FullName { get; private set; }
    public byte Image { get; private set; }
}
