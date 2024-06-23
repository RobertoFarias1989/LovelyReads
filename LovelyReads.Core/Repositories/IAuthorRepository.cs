using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IAuthorRepository
{
    //o que eu vou poder fazer com a minha entidade?
    //adicionar, atualizar, listar todos, listar um, deletar quem sabe...
    Task<List<Author>> GetAllAsync();
    Task<Author> GetByIdAsync(int id);
    Task<Author> GetDetailsByIdAsync(int id);
    Task AddAsync(Author author);
    Task UpdateAsync(Author author);

}
