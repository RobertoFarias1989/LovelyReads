using LovelyReads.Core.Entities;

namespace LovelyReads.UnitTests.Core.Entities;

public class UserBookReviewTests
{
    [Fact]
    public void TestIfUserBookReviewUpdateWorks()
    {
        //Arrange: instância da classe UserBookReview
        var userBookReview = new UserBookReview(5,"Leitura muito agradável", 1,2);

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(userBookReview);
        Assert.Equal(DateTime.Now.Date, userBookReview.CreatedAt.Date);
        Assert.Null(userBookReview.UpdatedAt);
        Assert.False(userBookReview.IsDeleted);
        Assert.Equal(1,userBookReview.IdUser);
        Assert.Equal(2, userBookReview.IdUserBook);
        Assert.InRange(userBookReview.Rating, 1, 5);
        Assert.Equal(5, userBookReview.Rating);
        Assert.Equal("Leitura muito agradável", userBookReview.Comment);

        //Act: verifico o funcionamento do método update
        userBookReview.Update(4, "Leitura muito agradável e produtiva.");

        // Assert: Verifico o resultado da atualização
        Assert.NotNull(userBookReview);
        Assert.NotNull(userBookReview.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, userBookReview.UpdatedAt.Value.Date);
        Assert.InRange(userBookReview.Rating, 1, 5);
        Assert.Equal(4, userBookReview.Rating);
        Assert.Equal("Leitura muito agradável e produtiva.", userBookReview.Comment);


    }

    [Fact]
    public void TestIfUserBookReviewDeleteWorks()
    {
        //Arrange: instância da classe UserBookReview
        var userBookReview = new UserBookReview(5, "Leitura muito agradável", 1, 2);

        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(userBookReview);
        Assert.False(userBookReview.IsDeleted);

        // Act: chamo o delete
        userBookReview.Delete();

        // Assert: Verifico se os valores foram atualizados corretamente
        Assert.NotNull(userBookReview);
        Assert.True(userBookReview.IsDeleted);
        Assert.NotNull(userBookReview.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, userBookReview.UpdatedAt.Value.Date);
    }
}
