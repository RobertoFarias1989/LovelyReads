using LovelyReads.Application.Book.Queries.GetBookById;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Book.Queries;

public class GetBookByIdQueryHandlerTests
{
    [Fact]
    public async Task ThereIsBook_Executed_ReturnBookDetailsViewModel()
    {
        //Arrange

        var book = new LovelyReads.Core.Entities.Book(
                "Hamlet",
                "A tragedy that tells the story of Prince Hamlet and his quest for revenge against his uncle, who has murdered Hamlet's father.",
                new LovelyReads.Core.ValueObjects.Edition(3, "Annotated Edition"),
                "978-0141396507",
                1,
                "Penguin Classics",
                2,
                1603,
                400,
                "BookStorage/Hamlet.jpg"
        );

        var bookUnitOfWork = Substitute.For<IUnitOfWork>();
        bookUnitOfWork.BookRepository.GetDetailsByIdAsync(1).Returns(book);

        var getBookByIdQuery = new GetBookByIdQuery(1);
        var getBookByIdQueryHandler = new GetBookByIdQueryHandler(bookUnitOfWork);

        //Act
        var bookDetailsViewModel = getBookByIdQueryHandler.Handle(getBookByIdQuery, new CancellationToken());

        //Assert
        Assert.NotNull(bookDetailsViewModel);

        await bookUnitOfWork.BookRepository.Received(1).GetDetailsByIdAsync(1);
    }
}
