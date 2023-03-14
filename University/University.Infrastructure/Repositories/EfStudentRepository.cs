using University.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Models;
using University.Core.Repositories.Interfaces;

namespace University.Infrastructure.Repositories
{
    public class EfStudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _context;

        public EfStudentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudents(int pagenumber, int pagesize)
        {
            var students = await _context.Students.Skip((pagenumber - 1) * 10).Take(pagesize).ToListAsync();
            return students;
        }
        public async Task<Student> GetInfoById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            return student;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async void AddNewStudent(Student student)
        {

            _context.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            _context.Students.Remove(student);
        }

    }
}
