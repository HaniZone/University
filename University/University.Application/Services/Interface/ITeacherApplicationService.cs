using University.Core.Models;

namespace University.Application.Services
{
    public interface ITeacherApplicationService
    {
        Task<int> NewTeacher(TeacherDto dto);
        Task<List<Teacher>> TeachersList(int pagenumber, int pagesize);
        Task<string> TeacherDiploma(TeacherDto dto);
        Task<bool> UpdateTeacherInfo(TeacherDto dto);
        Task<bool> DeleteTeacher(TeacherDto dto);
    }
}