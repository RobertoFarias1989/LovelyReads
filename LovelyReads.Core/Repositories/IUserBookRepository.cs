using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IUserBookRepository
{
    Task<List<UserBook>> GetAllAsync();
    Task<UserBook> GetByIdAsync(int id);
    Task<UserBook> GetDetailsByIdAsync(int id);
    Task AddAsync(UserBook userBook);
    void UpdateAsync(int id);
    Task DeleteAsync(int id);
}
