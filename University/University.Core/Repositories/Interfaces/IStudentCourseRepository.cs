using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public interface IStudentCourseRepository
    {
        Task<List<StudentCourse>> GetAllStudentCourses(int pagenumber, int pagesize);
        Task<StudentCourse> GetById(int id);
        Task<int> SaveChangesAsync();

        void AddNewAvailableCourse(StudentCourse studentCourse);
        //void DisableCourse(AvailableCourse availableCourse);
    }
}
