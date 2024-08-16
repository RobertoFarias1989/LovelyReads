using LovelyReads.Application.Book.ViewModels;

namespace LovelyReads.Application.Author.ViewModels;

public class AuthorDetailsViewModel
{
    public AuthorDetailsViewModel(int id,
        string born, string? died, string description, string fullName, string image, bool isDeleted, DateTime createdAt, DateTime? updatedAt, List<BookViewModel> bookViewModels)
    {
        Id = id;
        Born = born;
        Died = died;
        Description = description;
        FullName = fullName;
        Image = image;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        this.bookViewModels = bookViewModels;
    }

    public int Id { get; private set; }
    public string Born { get; private set; }
    public string? Died { get; private set; }
    public string Description { get; private set; }
    public string FullName { get; private set; }
    public string Image { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<BookViewModel> bookViewModels { get; private set; }
}
