﻿using LovelyReads.Core.ValueObjects;

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
        short pageAmount, decimal averageRating, string bookCover)
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
        AverageRating = averageRating;
        BookCover = bookCover;

        reviews = new List<BookReview>();
        UpdatedAt = null;
        IsActive = true;
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
    public List<BookReview>?  reviews { get; private set; }

   
    public void Update(string title,
        string description,
        Edition edition,
        string iSBN,
        int idAuthor,
        string publisher,
        int idGenre,
        short publishedYear,
        short pageAmount, decimal averageRating)
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
        AverageRating = averageRating;
    }

    public void UpdateBookCover(string path)
    {
        BookCover = path;
    }

}
