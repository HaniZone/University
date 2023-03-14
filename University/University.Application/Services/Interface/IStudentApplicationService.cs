using University.Core.Models;

namespace University.Application.Services.Interface
{
    public interface IStudentApplicationService
    {
        Task<int> NewStudent(StudentDto dto);
        Task<Student> GetStudentById(StudentDto dto);
        Task<List<Student>> StudentsList(int pagenumber , int pagesize);

        Task<bool> UpdateStudentInfo(StudentDto dto);

        Task<bool> DeleteStudent(StudentDto dto);
    }
}
