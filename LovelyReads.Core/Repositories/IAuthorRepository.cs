using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;

namespace LovelyReads.Core.Repositories;

public interface IAuthorRepository
{
    //o que eu vou poder fazer com a minha entidade?
    //adicionar, atualizar, listar todos, listar um, deletar quem sabe...
    Task<PaginationResult<Author>> GetAllAsync(string query, int page = 1);
    Task<Author?> GetByIdAsync(int id);
    Task<Author?> GetDetailsByIdAsync(int id);
    Task AddAsync(Author author);

}
