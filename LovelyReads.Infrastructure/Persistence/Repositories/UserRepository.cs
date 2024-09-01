using LovelyReads.Core.Entities;
using LovelyReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LovelyReadsDbContext _dbContext;

        public UserRepository(LovelyReadsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext
                .Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext
                .Users  
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetDetailsByIdAsync(int id)
        {
            return await _dbContext
                .Users
                .Include(u => u.BookReviews)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email.EmailAddress == email && u.Password.PasswordValue == passwordHash);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

    }
}
