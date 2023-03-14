using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public class EfUserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public EfUserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserbyUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            return user;
        }

        public async Task<User> GetUserbyUserId(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            return user;
        }

    }
}

