using LovelyReads.Core.Entities;

namespace LovelyReads.UnitTests.Core.Entities;

public class UserBookTests
{
    [Fact]
    public void TestIfUserBookUpdatePageAmountReadedWorks()
    {
        //Arrange: instância da classe UserBook
        var userBook = new UserBook(1,2,600);

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(userBook);
        Assert.Equal(DateTime.Now.Date, userBook.CreatedAt.Date);
        Assert.Equal(DateTime.Now.Date, userBook.StartToReadAt.Date);
        Assert.Null(userBook.UpdatedAt);
        Assert.Null(userBook.FinishReadAt);
        Assert.False(userBook.IsDeleted);
        Assert.Equal(0, userBook.PageAmountReaded);
        Assert.Equal(600, userBook.PageAmountToFinishRead);

        //Act: verifico o funcionamento do método UpdatePageAmountReaded
        userBook.UpdatePageAmountReaded();

        // Assert: Verifico o resultado da atualização
        Assert.NotNull(userBook);
        Assert.NotNull(userBook.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, userBook.UpdatedAt.Value.Date);
        Assert.False(userBook.IsDeleted);
        Assert.NotEqual(0, userBook.PageAmountReaded);

    }

    [Fact]
    public void TestIfFinishReadWorks()
    {
        //Arrange: instância da classe UserBook
        var userBook = new UserBook(1, 2, 600);

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(userBook);
        Assert.Null(userBook.FinishReadAt);

        //Act: verifico o funcionamento do método FinishRead
        userBook.UpdatePageAmountReaded();// tive que chamar esse método pois preciso que PageAmountReaded seja diferente de 0
        userBook.FinishRead();

        // Assert: Verifico o resultado da atualização
        Assert.NotEqual(0, userBook.PageAmountReaded);
        Assert.NotNull(userBook.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, userBook.UpdatedAt.Value.Date);
        Assert.NotNull(userBook.FinishReadAt);
        Assert.Equal(DateTime.Now.Date, userBook.FinishReadAt.Value.Date);

    }
}
