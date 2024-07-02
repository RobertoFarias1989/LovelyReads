using LovelyReads.Application.BookReview.ViewModels;

namespace LovelyReads.Application.Book.ViewModels;

public class BookDetailsViewModel
{
    public BookDetailsViewModel(string title,
        string description,
        string iSBN,
        int idAuthor,
        string authorFullName,
        string publisher,
        int idGenre,
        string genreDescription,
        short publishedYear,
        short pageAmount, decimal averageRating, byte bookCover, List<BookReviewViewModel> bookReviewsModel)
    {
        Title = title;
        Description = description;
        ISBN = iSBN;
        IdAuthor = idAuthor;
        AuthorFullName = authorFullName;
        Publisher = publisher;
        IdGenre = idGenre;
        GenreDescription = genreDescription;
        PublishedYear = publishedYear;
        PageAmount = pageAmount;
        AverageRating = averageRating;
        BookCover = bookCover;
        this.bookReviewsModel = bookReviewsModel;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ISBN { get; private set; }
    public int IdAuthor { get; private set; }
    public string AuthorFullName { get; private set; }
    public string Publisher { get; private set; }
    public int IdGenre { get; private set; }
    public string GenreDescription { get; private set; }
    public short PublishedYear { get; private set; }
    public short PageAmount { get; private set; }
    public decimal AverageRating { get; private set; }
    public byte BookCover { get; private set; }
    public List<BookReviewViewModel> bookReviewsModel { get; set; }
}
