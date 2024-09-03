using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;

namespace LovelyReads.Core.Repositories;

public interface IGenreRepository
{
    Task<PaginationResult<Genre>> GetAllAsync(string query, int page = 1);
    Task<Genre?> GetByIdAsync(int id);
    Task<Genre?> GetDetailsByIdAsync(int id);
    Task AddAsync(Genre genre);
}
