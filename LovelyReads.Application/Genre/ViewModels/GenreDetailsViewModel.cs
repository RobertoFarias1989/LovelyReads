using LovelyReads.Application.Book.ViewModels;

namespace LovelyReads.Application.Genre.ViewModels;

public class GenreDetailsViewModel
{
    public GenreDetailsViewModel(int id,
        string description,
        bool isDeleted,
        DateTime createdAt,
        DateTime? updatedAt,
        List<BookViewModel> bookViewModels)
    {
        Id = id;
        Description = description;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        this.bookViewModels = bookViewModels;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<BookViewModel> bookViewModels { get; private set; }
}
