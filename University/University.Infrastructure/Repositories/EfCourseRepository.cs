using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public class EfCourseRepository : ICourseRepository
    {
        private readonly DatabaseContext _context;

        public EfCourseRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<List<Course>> GetAllCourse(int pagenumber, int pagesize)
        {
            var course = await _context.Courses.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return course;
        }

        public async Task<Course> GetInfoById(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            return course;
        }

        public async Task<List<string>> GetUnitById(int id)
        {
            var teacher = await _context.Courses.Where(x => x.CourseId == id).Select(x => x.Unit + " " + x.CourseGp).ToListAsync();
            return teacher;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void AddNewCourse(Course cousre)
        {
            _context.Courses.Add(cousre);
        }

        public void RemoveCourse(Course cousre)
        {
            _context.Courses.Remove(cousre);
        }


    }
}
