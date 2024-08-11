namespace LovelyReads.Core.Entities;

public class Genre : BaseEntity
{
    public Genre()
    {
        
    }
    public Genre(string description)
    {
        Description = description;

        CreatedAt = DateTime.Now;
        UpdatedAt = null;
        IsDeleted = false;
        Books = new List<Book>();
   

    }

    public string Description { get; private set; }
    public List<Book>  Books { get; private set; }

    public void Update(string description)
    {
        Description = description;

        UpdatedAt = DateTime.Now;
    }
}
