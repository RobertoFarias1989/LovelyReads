using LovelyReads.Core.Entities;
using System;

namespace LovelyReads.UnitTests.Core.Entities;

public class GenreTests
{
    [Fact]
    public void TestIfGenreUpdateWorks()
    {
        //Arrange: instância da classe Genre
        var genre = new Genre(
            "Fiction: Imaginary narratives exploring various themes, characters, and worlds, often involving complex plots and creative storytelling.");

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(genre);
        Assert.Equal(DateTime.Now.Date,genre.CreatedAt.Date);
        Assert.False(genre.IsDeleted);
        Assert.Equal("Fiction: Imaginary narratives exploring various themes, characters, and worlds, often involving complex plots and creative storytelling.", genre.Description);

        //Act: verifico o funcionamento do método update
        genre.Update("Fiction: Imaginary narratives.");

        // Assert: Verifico o resultado da atualização
        Assert.NotNull(genre);
        Assert.NotNull(genre.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, genre.UpdatedAt.Value.Date);
        Assert.False(genre.IsDeleted);
        Assert.Equal("Fiction: Imaginary narratives.", genre.Description);
    }

    [Fact]
    public void TestIfGenreDeleteWorks()
    {
        //Arrange: instância da classe Genre
        var genre = new Genre(
            "Fiction: Imaginary narratives exploring various themes, characters, and worlds, often involving complex plots and creative storytelling.");

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(genre);
        Assert.False(genre.IsDeleted);

        // Act: chamo o delete
        genre.Delete();

        // Assert: Verifico se os valores foram atualizados corretamente
        Assert.NotNull(genre);
        Assert.True(genre.IsDeleted);
        Assert.NotNull(genre.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, genre.UpdatedAt.Value.Date);

    }
}
