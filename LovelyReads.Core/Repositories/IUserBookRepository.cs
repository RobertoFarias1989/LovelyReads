using LovelyReads.Core.DTOs;
using LovelyReads.Core.Entities;

namespace LovelyReads.Core.Repositories;

public interface IUserBookRepository
{
    Task<List<UserBook>> GetAllAsync();
    Task<List<UserBookDTO>> GetAllBooksReadedAsync(DateTime? startToReadAt, DateTime? finishReadAt);
    Task<UserBook?> GetByIdAsync(int id);
    Task<UserBook?> GetDetailsByIdAsync(int id);
    Task AddAsync(UserBook userBook);
}
