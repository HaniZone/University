using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface ISelectUnitCourseRepository
    {
        void AddNewSelectUnitCourse(SelectUnitCourse selectUnitCourse);
        Task<List<SelectUnitCourse>> GetAllSelectUnitCourse(int pagenumber, int pagesize);
        Task<SelectUnitCourse> GetCapabilityById(int id);
        Task<int> SaveChangesAsync();

    }
}