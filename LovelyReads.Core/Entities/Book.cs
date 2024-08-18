using LovelyReads.Core.ValueObjects;

namespace LovelyReads.Core.Entities;

public class Book : BaseEntity
{
    public Book()
    {
        
    }
    public Book(string title,
        string description,
        Edition edition,
        string iSBN,
        int idAuthor,
        string publisher,
        int idGenre,
        short publishedYear,
        short pageAmount, string bookCover)
    {
        Title = title;
        Description = description;
        Edition = edition;
        ISBN = iSBN;
        IdAuthor = idAuthor;
        Publisher = publisher;
        IdGenre = idGenre;
        PublishedYear = publishedYear;
        PageAmount = pageAmount; 
        BookCover = bookCover;

        CreatedAt = DateTime.Now;
        UpdatedAt = null;
        IsDeleted = false;
        AverageRating = 0;
        UserBooks = new List<UserBook>();       
      
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public Edition Edition { get; private set; }
    public string ISBN { get; private set; }
    public int IdAuthor { get; private set; }
    public Author? Author { get; private set; }
    public string Publisher { get; private set; }
    public int IdGenre { get; private set; }
    public Genre?  Genre { get; private set; }
    public short PublishedYear { get; private set; }
    public short PageAmount { get; private set; }
    public decimal AverageRating { get; private set; }
    public string BookCover { get; private set; }
    public List<UserBook> UserBooks { get; private set; }

    public void Update(string title,
        string description,
        Edition edition,
        string iSBN,
        int idAuthor,
        string publisher,
        int idGenre,
        short publishedYear,
        short pageAmount)
    {
        Title = title;
        Description = description;
        Edition = edition;
        ISBN = iSBN;
        IdAuthor = idAuthor;
        Publisher = publisher;
        IdGenre = idGenre;
        PublishedYear = publishedYear;
        PageAmount = pageAmount;

        UpdatedAt = DateTime.Now;
    }

    public void UpdateBookCover(string path)
    {
        BookCover = path;

        UpdatedAt = DateTime.Now;
    }

    //TODO: criar um método que permita deletar somente os livros que não estão com a FinishReadAt null

    //TODO : criar método para atualizar a AverageRating a cada avalição da UserBook

}
