﻿using LovelyReads.Core.ValueObjects;

namespace LovelyReads.Core.Entities;

public class Author : BaseEntity
{
    public Author(string born, string died,Name name ,byte image)
    {
        Born = born;
        Died = died;
        Name = name;
        Image = image;

        UpdatedAt = null;
        //Genres = new List<Genre>();
        Books = new List<Book>();
        
    }

    public string Born { get; private set; }
    public string Died { get; private set; }
    public Name Name { get; private set; }
    public byte Image { get; private set; }
    //public List<Genre> Genres { get; private set; }
    public List<Book>  Books { get; private set; }

    //o autor publica o livro...o livro pertence a um gênero...considerar isso na hora do relacionamento

}
