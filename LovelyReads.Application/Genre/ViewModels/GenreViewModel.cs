namespace LovelyReads.Application.Genre.ViewModels;

public class GenreViewModel
{
    public GenreViewModel(int id, string description, bool isActive, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Description = description;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
}
