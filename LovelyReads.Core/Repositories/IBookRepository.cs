using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;

namespace LovelyReads.Core.Repositories;

public interface IBookRepository
{
    Task<PaginationResult<Book>> GetAllAsync(string query, int page = 1);
    Task<Book?> GetByIdAsync(int id);
    Task<Book?> GetDetailsByIdAsync(int id);
    Task AddAsync(Book book);
}
