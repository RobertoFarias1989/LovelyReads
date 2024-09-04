using LovelyReads.Core.Entities;
using LovelyReads.Core.Models;
using LovelyReads.Core.Repositories;
using LovelyReads.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace LovelyReads.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LovelyReadsDbContext _dbContext;
        private const int PAGE_SIZE = 2;

        public UserRepository(LovelyReadsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<User>> GetAllAsync(string query, int page)
        {

            IQueryable<User> users = _dbContext.Users;

            if (!string.IsNullOrEmpty(query))
            {
                users = users.Where(u => u.Name.FullName.Contains(query) || u.Equals(query));
            }

            return await users.GetPaged<User>(page, PAGE_SIZE);

            //return await _dbContext
            //    .Users
            //    .AsNoTracking()
            //    .ToListAsync();
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
