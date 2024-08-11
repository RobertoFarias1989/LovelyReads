namespace LovelyReads.Application.Genre.ViewModels;

public class GenreViewModel
{
    public GenreViewModel(int id, string description, bool isDeleted, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Description = description;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
}
