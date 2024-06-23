namespace LovelyReads.Core.Entities;

public class Genre : BaseEntity
{
    public Genre(string description)
    {
        Description = description;

        UpdatedAt = null;
        Books = new List<Book>();

    }

    public string Description { get; private set; }
    public List<Book>  Books { get; private set; }
}
