using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers(int pagenumber, int pagesize);
        Task<Teacher> GetInfoById(int id);
        Task<string> GetLastDiplomaById(int id);
        Task<int> SaveChangesAsync();
        
        void AddNewTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
    }
}