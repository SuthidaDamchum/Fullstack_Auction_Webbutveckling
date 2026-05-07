using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionDbContext _context;

        public UserRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Where(user => user.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
