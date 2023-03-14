using University.Core.Models;

namespace University.Application.Services.Interface
{
    public interface ICourseApplicationService
    {
        Task<int> NewCourse(CourseDto dto);
        Task<Course> GetCourseById(CourseDto dto);
        Task<List<string>> GetUnitById(CourseDto dto);

        Task<List<Course>> CoursesList(int pagenumber, int pagesize);

        Task<bool> UpdateCourse(CourseDto dto);

        Task<bool> DeleteCourse(CourseDto dto);
    }
}
