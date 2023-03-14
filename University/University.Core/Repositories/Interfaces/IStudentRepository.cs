using University.Core.Models;

namespace University.Core.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents(int pagenumber, int pagesize);
        Task<Student> GetInfoById(int id);
        Task<int> SaveChangesAsync();

        void AddNewStudent(Student student);
        void RemoveStudent(Student student);

    }
}