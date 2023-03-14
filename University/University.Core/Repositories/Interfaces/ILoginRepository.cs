using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface ILoginRepository
    {
        Task<int> GetUserInfoById(int username , string pass);
    }
}