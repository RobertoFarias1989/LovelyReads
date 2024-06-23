using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface AuthorRepository
{
    //o que eu vou poder fazer com a minha entidade?
    //adicionar, atualizar, listar todos, listar um, deletar quem sabe...

    Task AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task<List<Author>> GetAllAsync();
    Task<Author> GetByIdAsync(int id);
}
