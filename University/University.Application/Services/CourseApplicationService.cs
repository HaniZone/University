using University.Application.Services.Interface;
using University.Core.Models;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class CourseApplicationService : ICourseApplicationService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CourseApplicationService(ICourseRepository courseRepository
            , ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<int> NewCourse(CourseDto dto)
        {

            var newCourse = new Course(dto.TeacherId , dto.CourseName , dto.Unit , dto.CourseGp , dto.IsOptional);

            var teacher = await _teacherRepository.GetInfoById(dto.TeacherId);
            if (teacher == null)
                throw new ApplicationException("Teacher is not exist");

            _courseRepository.AddNewCourse(newCourse);

            await _courseRepository.SaveChangesAsync();
            return newCourse.CourseId;
        }

        public async Task<List<Course>> CoursesList(int pagenumber, int pagesize)
        {
            var courses = await _courseRepository.GetAllCourse(pagenumber, pagesize);
            return courses;
        }

        public async Task<Course> GetCourseById(CourseDto dto)
        {
            var course = await _courseRepository.GetInfoById(dto.CourseId);
            return course;
        }

        public async Task<List<string>> GetUnitById(CourseDto dto)
        {
            var unit = await _courseRepository.GetUnitById(dto.CourseId);
            return unit;
        }
        public async Task<bool> UpdateCourse(CourseDto dto)
        {
            var course = await _courseRepository.GetInfoById(dto.CourseId);
            if (course == null)
                throw new ApplicationException("Course not found");

            course.CourseName = dto.CourseName;
            course.Unit = dto.Unit;
            course.CourseGp = dto.CourseGp;
            if (course.IsOptional)
            {
                course.Optional();
            }
            else
            {
                course.NotOptional();
            }

            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourse(CourseDto dto)
        {
            var course = await _courseRepository.GetInfoById(dto.CourseId);
            if (course == null)
                throw new ApplicationException("Course not found");

            _courseRepository.RemoveCourse(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

    }
}
