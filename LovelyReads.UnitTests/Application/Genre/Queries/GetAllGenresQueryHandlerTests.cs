using LovelyReads.Application.Genre.Queries.GetAllGenre;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Genre.Queries;

public class GetAllGenresQueryHandlerTests
{
    [Fact]
    public async Task ThereAreGenres_Execute_ReturnGenreViewModel()
    {
        //Arrange

        var genres = new List<LovelyReads.Core.Entities.Genre>
        {
            new LovelyReads.Core.Entities.Genre(
                "Fiction: Imaginary narratives exploring various themes, characters, and worlds, often involving complex plots and creative storytelling."),

            new LovelyReads.Core.Entities.Genre(
                "Biography: A detailed account of a person's life, chronicling significant events, achievements, and personal experiences."),

            new LovelyReads.Core.Entities.Genre(
                "Science Fiction: Stories exploring futuristic concepts, advanced technology, space exploration, and often speculative scientific ideas.")
        };

        var paginationResult = new PaginationResult<LovelyReads.Core.Entities.Genre>
        {
            Page = 1,
            TotalPages = 1,
            PageSize = 10,
            ItemsCount = genres.Count,
            Data = genres
        };

        var genreUnitOfWork = Substitute.For<IUnitOfWork>();
        genreUnitOfWork.GenreRepository.GetAllAsync("").Returns(paginationResult);

        var getAllGenresQuery = new GetAllGenresQuery("", 1);
        var getAllGenresQueryHandler = new GetAllGenresQueryHandler(genreUnitOfWork);

        //Act
        var genreViewModelList = getAllGenresQueryHandler.Handle(getAllGenresQuery, new CancellationToken());

        //Assert
        Assert.NotNull(genreViewModelList);
        Assert.NotEmpty(genreViewModelList.Result.Data);

        await genreUnitOfWork.GenreRepository.Received(1).GetAllAsync("");

    }
}
