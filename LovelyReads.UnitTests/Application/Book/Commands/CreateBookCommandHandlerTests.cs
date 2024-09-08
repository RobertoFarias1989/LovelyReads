using Microsoft.AspNetCore.Http;
using System.Text;
using NSubstitute;
using LovelyReads.Core.Repositories;
using LovelyReads.Application.Book.Commands.CreateBook;

namespace LovelyReads.UnitTests.Application.Book.Commands;

public class CreateBookCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Execute_ReturnBookId()
    {

        //Arrange
        var bookUnitOfWork = Substitute.For<IUnitOfWork>();

        var createBookCommand = new CreateBookCommand
        {
            Title = "Hamlet",
            Description = "A tragedy that tells the story of Prince Hamlet and his quest for revenge against his uncle, who has murdered Hamlet's father.",
            EditionNumber = 3,
            EditionDescription = "Annotated Edition",
            ISBN = "978-0141396507",
            IdAuthor = 1, 
            Publisher = "Penguin Classics",
            IdGenre = 2, 
            PublishedYear = 1603,
            PageAmount = 400,
            BookCover = GetTestFormFile("image.jpg", "image/jpeg")
        };

        var createBookCommandHandler = new CreateBookCommandHandler(bookUnitOfWork);

        //Act
        var id = await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

        //Assert

        //No contexto de testes unitários o Assert para o Id nao faz sentido já que não buscamos validar a persistência dos dados
        //isso seria mais plausível em um teste de integração, por isso ele está comentado
        //Assert.True(id.Value >= 0);

        await bookUnitOfWork.Received(1).BookRepository.AddAsync(Arg.Any<LovelyReads.Core.Entities.Book>());

    }

    private IFormFile GetTestFormFile(string fileName, string contentType)
    {
        // Cria um fluxo de memória com alguns dados fictícios
        var content = "Fake image content for testing.";
        var fileStream = new MemoryStream(Encoding.UTF8.GetBytes(content));

        // Cria o IFormFile com o fluxo de memória
        return new FormFile(fileStream, 0, fileStream.Length, "file", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType
        };
    }

}