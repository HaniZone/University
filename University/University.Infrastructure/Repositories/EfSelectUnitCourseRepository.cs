using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;

namespace University.Infrastructure.Repositories
{
    public class EfSelectUnitCourseRepository : ISelectUnitCourseRepository
    {
        private readonly DatabaseContext _context;

        public EfSelectUnitCourseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddNewSelectUnitCourse(SelectUnitCourse selectUnitCourse)
        {
            _context.SelectUnitCourses.Add(selectUnitCourse);
        }

        public async Task<List<SelectUnitCourse>> GetAllSelectUnitCourse(int pagenumber, int pagesize)
        {
            var courses = await _context.SelectUnitCourses.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return courses;
        }

        public async Task<SelectUnitCourse> GetCapabilityById(int id)
        {
            var capability = await _context.SelectUnitCourses.FirstOrDefaultAsync(x => x.SelectUnitCourseId == id);
            return capability;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
