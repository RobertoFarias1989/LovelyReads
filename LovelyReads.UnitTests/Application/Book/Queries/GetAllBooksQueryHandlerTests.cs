using LovelyReads.Application.Book.Queries.GetAllBooks;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Book.Queries;

public class GetAllBooksQueryHandlerTests
{
    [Fact]
    public async Task ThereAreBooks_Execute_ReturnBookViewModel()
    {
        //Arrange

        var books = new List<LovelyReads.Core.Entities.Book>()
        {
            new LovelyReads.Core.Entities.Book(
                "Hamlet",
                "A tragedy that tells the story of Prince Hamlet and his quest for revenge against his uncle, who has murdered Hamlet's father.",
                new LovelyReads.Core.ValueObjects.Edition(3,"Annotated Edition"),          
                "978-0141396507",
                1,
                "Penguin Classics",
                2,
                1603,
                400,
                "BookStorage/Hamlet.jpg"
                ),

            new LovelyReads.Core.Entities.Book(
                "Crime and Punishment",
                "A psychological drama that delves into the mind of a young man, Raskolnikov, who commits a crime and grapples with guilt and redemption.",
                new LovelyReads.Core.ValueObjects.Edition(4,"Critical Edition"),
                "978-0143058144",
                3,
                "Penguin Classics",
                3,
                1866,
                671,
                "BookStorage/CrimePunishiment.jpg"
                )
        };

        var paginationResult = new PaginationResult<LovelyReads.Core.Entities.Book>
        {
            Page = 1,
            TotalPages = 1,
            PageSize = 10,
            ItemsCount = books.Count,
            Data = books
        };

        var bookUnitOfWork = Substitute.For<IUnitOfWork>();
        bookUnitOfWork.BookRepository.GetAllAsync("").Returns(paginationResult);

        var getAllBooksQuery = new GetAllBooksQuery("",1);
        var getAllBooksQueryHandler = new GetAllBooksQueryHandler(bookUnitOfWork);

        //Act
        var bookViewModelList = getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

        //Assert
        Assert.NotNull(bookViewModelList);
        Assert.NotEmpty(bookViewModelList.Result.Data);

        await bookUnitOfWork.BookRepository.Received(1).GetAllAsync("");

    }
}
