using LovelyReads.Application.Genre.Queries.GetGenreById;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Genre.Queries;

public class GetGenreByIdQueryHandlerTests
{
    [Fact]
    public async Task ThereIsGenre_Executed_ReturnGenreDetailsViewModel()
    {
        //Arrange

        var genre = new LovelyReads.Core.Entities.Genre(
            "Fiction: Imaginary narratives exploring various themes, characters, and worlds, often involving complex plots and creative storytelling.");

        var genreUnitOfWork = Substitute.For<IUnitOfWork>();
        genreUnitOfWork.GenreRepository.GetDetailsByIdAsync(1).Returns(genre);

        var getGenreByIdQuery = new GetGenreByIdQuery(1);
        var getGenreByIdQueryHandler = new GetGenreByIdQueryHandler(genreUnitOfWork);

        //Act
        var genreDetailsViewModel = await getGenreByIdQueryHandler.Handle(getGenreByIdQuery, new CancellationToken());

        //Assert
        Assert.NotNull(genreDetailsViewModel);

        await genreUnitOfWork.GenreRepository.Received(1).GetDetailsByIdAsync(1);
    }
}
