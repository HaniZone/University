  using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserbyUsername(string username);
        Task<User> GetUserbyUserId(int userId);


    }
}