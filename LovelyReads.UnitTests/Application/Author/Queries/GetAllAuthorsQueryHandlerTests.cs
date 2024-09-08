using LovelyReads.Application.Author.Queries.GetAllAuthors;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Core.ValueObjects;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Author.Queries;

public class GetAllAuthorsQueryHandlerTests
{
    [Fact]
    public async Task AuthorsExiste_Executed_ReturnAuthorViewModel()
    {
        //Arrange      

        var authors = new List<LovelyReads.Core.Entities.Author>
        {
            new LovelyReads.Core.Entities.Author(
                "April 23, 1564",
                "April 23, 1616",
                "William Shakespeare was an English playwright, poet, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist.",
                new Name("William Shakespeare"),
                "Um caminho qualquer só para testar"
            ),

            new LovelyReads.Core.Entities.Author(
                "February 7, 1812",
                "June 9, 1870",
                "Charles Dickens was an English writer and social critic.",
                new Name("Charles Dickens"),
                "Um caminho qualquer só para testar"
            ),

            new LovelyReads.Core.Entities.Author(
                "November 11, 1821",
                "February 9, 1881",
                "Fyodor Dostoevsky was a Russian novelist, short story writer, essayist, and philosopher.",
                new Name("Fyodor Dostoevsky"),
                "Um caminho qualquer só para testar"
            )
        };

        var paginationResult = new PaginationResult<LovelyReads.Core.Entities.Author>
        {
            Page = 1,
            TotalPages = 1,
            PageSize = 10,
            ItemsCount = authors.Count,
            Data = authors
        };

        var authorUnitOfWork = Substitute.For<IUnitOfWork>();
        authorUnitOfWork.AuthorRepository.GetAllAsync("").Returns(paginationResult);

        var getAllAuthorsQuery = new GetAllAuthorsQuery("", 1);
        var getAllAuthorsQueryHandler = new GetAllAuthorsQueryHandler(authorUnitOfWork);

        //Act
        var auhtorViewModelList = await getAllAuthorsQueryHandler.Handle(getAllAuthorsQuery, new CancellationToken());

        //Assert
        Assert.NotNull(auhtorViewModelList);
        Assert.NotEmpty(auhtorViewModelList.Data);

        await authorUnitOfWork.AuthorRepository.Received(1).GetAllAsync("");
    }
}
