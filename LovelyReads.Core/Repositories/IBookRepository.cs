using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task<Book> GetDetailsByIdAsync(int id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
}
