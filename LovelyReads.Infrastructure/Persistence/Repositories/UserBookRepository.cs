using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories;

public class UserBookRepository : IUserBookRepository
{
    private readonly LovelyReadsDbContext _dbContext;

    public UserBookRepository(LovelyReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserBook>> GetAllAsync()
    {
        return await _dbContext.UserBooks.AsNoTracking().ToListAsync();
    }

    public async Task<UserBook?> GetByIdAsync(int id)
    {
        return await _dbContext.UserBooks.SingleOrDefaultAsync(ub => ub.Id == id);
    }

    public async Task<UserBook?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext
            .UserBooks
            .Include(ub => ub.Reviews)
            .SingleOrDefaultAsync(ub => ub.Id == id);
    }
    public async Task AddAsync(UserBook userBook)
    {
        await _dbContext.UserBooks.AddAsync(userBook);
    }
}
