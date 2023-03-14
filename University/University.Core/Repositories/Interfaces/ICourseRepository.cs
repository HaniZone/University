using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourse(int pagenumber, int pagesize);
        Task<Course> GetInfoById(int id);
        Task<List<string>> GetUnitById(int id);
        Task<int> SaveChangesAsync();

        void AddNewCourse(Course cousre);
        void RemoveCourse(Course cousre);
    }
}