using LovelyReads.Core.Entities;
using LovelyReads.Core.ValueObjects;

namespace LovelyReads.UnitTests.Core.Entities;

public class AuthorTests
{
    [Fact]
    public void TestIfAuthorUpdateWorks()
    {
        //Arrange: instância da classe Author
        var author = new Author(
            "April 23, 1564",
            "April 23, 1616",
            "William Shakespeare was an English playwright, poet, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist.",
            new Name("William Shakespeare"),
            "Um caminho qualquer só para testar"
            );

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(author);
        Assert.Equal(DateTime.Now.Date, author.CreatedAt.Date);
        Assert.False(author.IsDeleted);
        Assert.Equal("April 23, 1616", author.Died);
        Assert.Equal("William Shakespeare was an English playwright, poet, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist.", author.Description);
        Assert.Equal("William Shakespeare", author.Name.FullName);
        Assert.Equal("Um caminho qualquer só para testar", author.Image);

        //Act: o método update é chamado atualizando o Author
        author.Update(
            "April 23, 1564",
            "April 23, 1616",
            "William Shakespeare was an English playwright, poet, and actor.",
            new Name("William Shakespeare UPDATED"));

        author.UpdateImage("Um novo caminho para imagem ATUALIZADO");

        // Assert: Verifico se os valores foram atualizados corretamente
        Assert.NotNull(author);
        Assert.NotNull(author.UpdatedAt);
        Assert.Equal("April 23, 1564", author.Born);
        Assert.Equal("April 23, 1616", author.Died);
        Assert.Equal("William Shakespeare was an English playwright, poet, and actor.", author.Description);
        Assert.Equal("William Shakespeare UPDATED", author.Name.FullName);
        Assert.Equal("Um novo caminho para imagem ATUALIZADO", author.Image);

    }

    [Fact]
    public void TestIfAuthorDeleteWorks()
    {
        //Arrange: instância da classe Author
        var author = new Author(
            "April 23, 1564",
            "April 23, 1616",
            "William Shakespeare was an English playwright, poet, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist.",
            new Name("William Shakespeare"),
            "Um caminho qualquer só para testar"
            );

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(author);

        //Act: chamo o delete 
        author.Delete();

        // Assert: Verifico se os valores foram atualizados corretamente
        Assert.NotNull(author);
        Assert.True(author.IsDeleted);
        Assert.NotNull(author.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, author.UpdatedAt.Value.Date);

    }
}
