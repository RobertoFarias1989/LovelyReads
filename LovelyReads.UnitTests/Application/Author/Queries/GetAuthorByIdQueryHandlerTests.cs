using LovelyReads.Application.Author.Queries.GetAuthorById;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.ValueObjects;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Author.Queries;

public class GetAuthorByIdQueryHandlerTests
{
    [Fact]
    public async Task IdIsNotNull_Execute_ReturnAuthorDetailsViewModel()
    {
        //Arrange

        var author = new LovelyReads.Core.Entities.Author(
                "November 11, 1821",
                "February 9, 1881",
                "Fyodor Dostoevsky was a Russian novelist, short story writer, essayist, and philosopher.",
                new Name("Fyodor Dostoevsky"),
                "Um caminho qualquer só para testar");



        var authorUnitOfWork = Substitute.For<IUnitOfWork>();
        authorUnitOfWork.AuthorRepository.GetDetailsByIdAsync(1).Returns(author);

        var getAuthorByIdQuery = new GetAuthorByIdQuery(1);
        var getAuthorByIdQueryHandler = new GetAuthorByIdQueryHandler(authorUnitOfWork);

        //Act
        var authorDetailsViewModel = await getAuthorByIdQueryHandler.Handle(getAuthorByIdQuery, new CancellationToken());

        //Assert
        Assert.NotNull(authorDetailsViewModel);       


        await authorUnitOfWork.AuthorRepository.Received(1).GetDetailsByIdAsync(1);
    }
}
