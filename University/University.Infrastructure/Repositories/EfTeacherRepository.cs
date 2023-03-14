using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;
using University.Core.Repositories.Interfaces;

namespace University.Infrastructure.Repositories
{
    public class EfTeacherRepository : ITeacherRepository
    {
        private readonly DatabaseContext _context;

        public EfTeacherRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllTeachers(int pagenumber, int pagesize)
        {
            var teacher = await _context.Teachers.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return teacher;
        }
        public async Task<Teacher> GetInfoById(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            return teacher;
        }

        public async Task<string> GetLastDiplomaById(int id)
        {
            var teacher = await _context.Teachers.Where(x => x.TeacherId == id).Select(x => x.LastDiploma).FirstOrDefaultAsync();
            return teacher;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void AddNewTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }

    }
}
