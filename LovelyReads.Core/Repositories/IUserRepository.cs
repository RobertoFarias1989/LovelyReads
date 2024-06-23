using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> GetDetailsByIdAsync(int id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}
