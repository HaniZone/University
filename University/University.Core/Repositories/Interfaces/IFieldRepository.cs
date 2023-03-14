using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface IFieldRepository
    {
        Task<List<Field>> GetAllField(int pagenumber, int pagesize);
        Task<Field> GetInfoById(int id);
        Task<int> SaveChangesAsync();

        void AddNewField(Field field);
        void RemoveField(Field field);
    }
}