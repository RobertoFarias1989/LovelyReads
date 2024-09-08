using LovelyReads.Application.Author.Commands.CreateAuthor;
using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LovelyReads.UnitTests.Application.Author.Commands;

public class CreateAuthorCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnAuthorId()
    {
        //Arrange
        var authorUnitOfWork = Substitute.For<IUnitOfWork>();

        var createAuthorCommand = new CreateAuthorCommand
        {
            Born = "April 23, 1564",
            Died = "April 23, 1616",
            Description = "William Shakespeare was an English playwright, poet, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist.",
            FullName = "William Shakespeare",
            Image = GetTestFormFile("image.jpg", "image/jpeg")
        };


        var createAuthorCommandHandler = new CreateAuthorCommandHandler(authorUnitOfWork);

        //Act
        var id = await createAuthorCommandHandler.Handle(createAuthorCommand, new CancellationToken());

        // Assert 
        Assert.True(id.Value > 0);

        await authorUnitOfWork.Received(1).AuthorRepository.AddAsync(Arg.Any<LovelyReads.Core.Entities.Author>());

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
