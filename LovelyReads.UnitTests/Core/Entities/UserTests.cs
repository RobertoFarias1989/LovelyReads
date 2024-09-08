using LovelyReads.Core.Entities;
using LovelyReads.Core.ValueObjects;

namespace LovelyReads.UnitTests.Core.Entities;

public class UserTests
{
    [Fact]
    public void TestIfUserUpdateWors()
    {
        //Arrange: instância da classe User
        var user = new User(
            new Address("Avenida T, 879", "Rio de Janeiro", "RJ", "20000-000", "Brasil"),
            new CPF("98765432199"),
            new Email("carla.souza@example.com"),
            new Name("Carla de Souza"),
            new Password("Qualquer coisa só para passar"),
            "manager");

        //Verifico se o construtor da classe está funcionando corretamente,
        Assert.NotNull(user);
        Assert.False(user.IsDeleted);
        Assert.Equal(DateTime.Now.Date, user.CreatedAt.Date);
        Assert.Null(user.UpdatedAt);

        // Verifico o CPF, Email, Nome, Senha e Role do usuário
        Assert.Equal("98765432199", user.CPF.CPFNumber);
        Assert.Equal("carla.souza@example.com", user.Email.EmailAddress);
        Assert.Equal("Carla de Souza", user.Name.FullName);
        Assert.Equal("Qualquer coisa só para passar", user.Password.PasswordValue);
        Assert.Equal("manager", user.Role);

        //Verifico o Address
        Assert.Equal("Avenida T, 879", user.Address.Street);
        Assert.Equal("Rio de Janeiro", user.Address.City);
        Assert.Equal("RJ", user.Address.State);
        Assert.Equal("20000-000", user.Address.PostalCode);
        Assert.Equal("Brasil", user.Address.Country);

        //Act: verifico o funcionamento do método update
        user.Update(
            new Address("Avenida T, 879 ATUALIZADA", "Rio de Janeiro ATUAL", "RJ", "20000-000", "Brasil"),
            new CPF("98765432199"),
            new Email("carla.souza@example.com"),
            new Name("Carla de Souza CAMARGO"),
            new Password("Qualquer coisa só para passar"));


        // Assert: Verifico o resultado da atualização
        Assert.NotNull(user);
        Assert.NotNull(user.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, user.UpdatedAt.Value.Date);
        Assert.False(user.IsDeleted);

        // Verifico o CPF, Email, Nome, Senha e Role do usuário
        Assert.Equal("98765432199", user.CPF.CPFNumber);
        Assert.Equal("carla.souza@example.com", user.Email.EmailAddress);
        Assert.Equal("Carla de Souza CAMARGO", user.Name.FullName);
        Assert.Equal("Qualquer coisa só para passar", user.Password.PasswordValue);

        //Verifico o Address
        Assert.Equal("Avenida T, 879 ATUALIZADA", user.Address.Street);
        Assert.Equal("Rio de Janeiro ATUAL", user.Address.City);
        Assert.Equal("RJ", user.Address.State);
        Assert.Equal("20000-000", user.Address.PostalCode);
        Assert.Equal("Brasil", user.Address.Country);
    }

    [Fact]
    public void TestIfUserDeleteWors()
    {

        //Arrange: instância da classe User
        var user = new User(
            new Address("Avenida T, 879", "Rio de Janeiro", "RJ", "20000-000", "Brasil"),
            new CPF("98765432199"),
            new Email("carla.souza@example.com"),
            new Name("Carla de Souza"),
            new Password("Qualquer coisa só para passar"),
            "manager");


        //Verifico se o construtor da classe está funcionando corretamente
        Assert.NotNull(user);
        Assert.False(user.IsDeleted);


        // Act: chamo o delete
        user.Delete();

        // Assert: Verifico se os valores foram atualizados corretamente
        Assert.NotNull(user);
        Assert.True(user.IsDeleted);
        Assert.NotNull(user.UpdatedAt);
        Assert.Equal(DateTime.Now.Date, user.UpdatedAt.Value.Date);

    }

}
