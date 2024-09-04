using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;

namespace LovelyReads.Core.Repositories;

public interface IUserRepository
{
    Task<PaginationResult<User>> GetAllAsync(string query, int page = 1);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetDetailsByIdAsync(int id);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task AddAsync(User user);

}
