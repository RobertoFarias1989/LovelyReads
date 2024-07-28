namespace LovelyReads.Application.Book.ViewModels;

public class BookViewModel
{
    public BookViewModel(int id, string title, short publishedYear, decimal averageRating, string bookCover)
    {
        Id = id;
        Title = title;
        PublishedYear = publishedYear;
        AverageRating = averageRating;
        BookCover = bookCover;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public short PublishedYear { get; private set; }
    public decimal AverageRating { get; private set; }
    public string BookCover { get; private set; }
}
