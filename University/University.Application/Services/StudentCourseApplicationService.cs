using University.Application.Services.Interface;
using University.Core.Models;
using University.Core.Repositories.Interfaces;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class StudentCourseApplicationService : IStudentCourseApplicationService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentCourseApplicationService(IStudentCourseRepository studentCourseRepository
            , IStudentRepository studentRepository
            , ICourseRepository courseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }




        public async Task<int> NewStudentCourse(StudentCourseDto dto)
        {
            var course = await _courseRepository.GetInfoById(dto.CourseId);
            var student = await _studentCourseRepository.GetById(dto.StudentId);
            if (student == null & course == null)
                throw new ApplicationException("StudentCourse not found ");

            var newStudentCourse = new StudentCourse(dto.StudentId , dto.CourseId);
            _studentCourseRepository.AddNewAvailableCourse(newStudentCourse);

            await _studentCourseRepository.SaveChangesAsync();
            return newStudentCourse.Id;
        }

        public async Task<StudentCourse> GetStudentCourseById(StudentCourseDto dto)
        {
            var Info = await _studentCourseRepository.GetById(dto.Id);
            return Info;
        }
        public async Task<List<StudentCourse>> lists(int pagenumber, int pagesize)
        {
            var studentsList = await _studentCourseRepository.GetAllStudentCourses(pagenumber, pagesize);
            return studentsList;
        }

        /* public async Task<bool> UpdateStudentInfo(StudentDto dto)
       {
           var student = await _studentRepository.GetInfoById(dto.SudentId);
           if (student == null)
               throw new ApplicationException("Student not found");

           student.Name = dto.Name;
           student.LastName = dto.LastName;
           student.NationalCode = dto.NationalCode;
           student.PhoneNumber = dto.PhoneNumber;
           student.BirthDay = dto.BirthDay;
           student.Field = dto.Field;

           await _studentRepository.SaveChangesAsync();
           return true;
       }

       public async Task<bool> DeleteStudent(StudentDto dto)
       {
           var student = await _studentRepository.GetInfoById(dto.SudentId);
           if (student == null)
               throw new ApplicationException("Student not found");
           _studentRepository.RemoveStudent(student);
           await _studentRepository.SaveChangesAsync();
           return true;

       }*/
    }
}
