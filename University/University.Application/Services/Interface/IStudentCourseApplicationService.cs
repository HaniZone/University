using University.Core.Models;

namespace University.Application.Services.Interface
{
    public interface IStudentCourseApplicationService
    {
        Task<int> NewStudentCourse(StudentCourseDto dto);
        Task<StudentCourse> GetStudentCourseById(StudentCourseDto dto);
        Task<List<StudentCourse>> lists(int pagenumber, int pagesize);

        //Task<bool> UpdateStudentCourseInfo(StudentDto dto);

        //Task<bool> DeleteStudentCourse(StudentDto dto);
    }
}
