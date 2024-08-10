using LovelyReads.Core.ValueObjects;

namespace LovelyReads.Core.Entities;

public class Author : BaseEntity
{
    public Author()
    {
            
    }
    public Author(string born, string died, string description ,Name name ,string image)
    {
        Born = born;
        Died = died;
        Description = description;
        Name = name;
        Image = image;

        IsDeleted = false;
        UpdatedAt = null;
        //Genres = new List<Genre>();
        Books = new List<Book>();
        
    }

    public string Born { get; private set; }
    public string Died { get; private set; }
    public string Description { get; private set; }
    public Name Name { get; private set; }
    public string Image { get; private set; }
    //public List<Genre> Genres { get; private set; }
    public List<Book>  Books { get; private set; }

    //o autor publica o livro...o livro pertence a um gênero...considerar isso na hora do relacionamento

    public void Update(string born, string died, string description, Name name)
    {
        Born = born;
        Died = died;
        Description = description;
        Name = name;    

        UpdatedAt = DateTime.Now;
    }

    public void UpdateImage(string path)
    {
        Image = path;
    }

}
