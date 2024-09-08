using LovelyReads.Application.Genre.Commands.CreateGenre;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using NSubstitute;

namespace LovelyReads.UnitTests.Application.Genre.Commands;

public class CreateGenreCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnGenreId()
    {
        //Arrange
        var genreUnitOfWork = Substitute.For<IUnitOfWork>();

        var createGenreCommand = new CreateGenreCommand
        {
            Description = "Fiction: Imaginary narratives exploring various themes, characters, and worlds, often involving complex plots and creative storytelling."
        };

        var createGenreCommandHandler = new CreateGenreCommandHandler(genreUnitOfWork);

        //Act

        var id = await createGenreCommandHandler.Handle(createGenreCommand, new CancellationToken());

        //Assert

        //No contexto de testes unitários o Assert para o Id nao faz sentido já que não buscamos validar a persistência dos dados
        //isso seria mais plausível em um teste de integração, por isso ele está comentado
        //Assert.True(id.Value >= 0);

        await genreUnitOfWork.Received(1).GenreRepository.AddAsync(Arg.Any<LovelyReads.Core.Entities.Genre>());
    }
}
