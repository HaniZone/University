using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public class EfStudentCourseRepository : IStudentCourseRepository
    {
        private readonly DatabaseContext _context;

        public EfStudentCourseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddNewAvailableCourse(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
        }

        public async Task<List<StudentCourse>> GetAllStudentCourses(int pagenumber, int pagesize)
        {
            var course = await _context.StudentCourses.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return course;
        }

        public async Task<StudentCourse> GetById(int id)
        {
            var studentCourse = await _context.StudentCourses.FirstOrDefaultAsync(x => x.Id == id);
            return studentCourse;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
