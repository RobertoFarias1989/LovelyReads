namespace LovelyReads.Core.Entities;

public class Author : BaseEntity
{
    public Author(string born, string died, byte image)
    {
        Born = born;
        Died = died;

        UpdatedAt = null;
        //Genres = new List<Genre>();
        Books = new List<Book>();
        Image = image;
    }

    public string Born { get; private set; }
    public string Died { get; private set; }
    public byte Image { get; private set; }
    //public List<Genre> Genres { get; private set; }
    public List<Book>  Books { get; private set; }

    //o autor publica o livro...o livro pertence a um gênero...considerar isso na hora do relacionamento

}
