using University.Core.Models;

namespace University.Application.Services
{
    public interface ISelectUnitCourseApplicationService
    {
        Task<int> NewSelectUnitCourse(SelectUnitCourseDto dto);
        Task<List<SelectUnitCourse>> UnitCoursesList(int pagenumber, int pagesize);
        Task<SelectUnitCourse> GetCapabilityById(SelectUnitCourseDto dto);
        Task<bool> UpdateSelectUnitCourse(SelectUnitCourseDto dto);
    }
}