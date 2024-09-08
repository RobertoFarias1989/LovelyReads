using LovelyReads.Application.UserBook.Queries.GetAllUserBook;
using LovelyReads.Core.DTOs;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.UserBook.Queries;

public class GetAllUserBooksQueryHandlerTests
{
    [Fact]
    public async Task ThereAreUserBooks_Execute_ReturnUserBookViewModel()
    {
        //Arrange

        var userBooks = new List<UserBookDTO>
        {
            new UserBookDTO(1, 1, 2, DateTime.Now.AddDays(-10), DateTime.Now, 150, 50),
            new UserBookDTO(1, 1, 5, DateTime.Now.AddDays(-10), DateTime.Now, 150, 50),
        };

        var userBookUnitOfWork = Substitute.For<IUnitOfWork>();
        userBookUnitOfWork.UserBookRepository.GetAllBooksReadedAsync(null,null).Returns(userBooks);

        var getAllUserBooksQuery = new GetAllUserBooksQuery(null,null);
        var getAllUserBooksQueryHandler = new GetAllUserBooksQueryHandler(userBookUnitOfWork);

        // Act
        var result = await getAllUserBooksQueryHandler.Handle(getAllUserBooksQuery, new CancellationToken());

        //Assert
        Assert.NotNull(result);

        await userBookUnitOfWork.UserBookRepository.Received(1).GetAllBooksReadedAsync(null, null);
    }
}
