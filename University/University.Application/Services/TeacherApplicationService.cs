using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.Models;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class TeacherApplicationService : ITeacherApplicationService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherApplicationService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int> NewTeacher(TeacherDto dto)
        {
            var newTeacher =new Teacher(dto.TeacherName , dto.TeacherLastName , dto.TeacherNationalCode , dto.LastDiploma , dto.TeacherBirthDay);
            _teacherRepository.AddNewTeacher(newTeacher);
            
            await _teacherRepository.SaveChangesAsync();
            return newTeacher.TeacherId;
        }


        public async Task<List<Teacher>> TeachersList(int pagenumber, int pagesize)
        {
            var teachers = await _teacherRepository.GetAllTeachers(pagenumber, pagesize);
            return teachers;
        }
        public async Task<string> TeacherDiploma(TeacherDto dto)
        {
            var diploma = await _teacherRepository.GetLastDiplomaById(dto.TeacherId);
            return diploma;
        }

        public async Task<bool> UpdateTeacherInfo(TeacherDto dto)
        {
            var teacher = await _teacherRepository.GetInfoById(dto.TeacherId);
            if (teacher == null)
                throw new Exception("Teacher not Found");

            teacher.TeacherName = dto.TeacherName;
            teacher.TeacherLastName = dto.TeacherLastName;
            teacher.TeacherNationalCode = dto.TeacherNationalCode;
            teacher.TeacherBirthDay = dto.TeacherBirthDay;
            teacher.LastDiploma = dto.LastDiploma;

            await _teacherRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeacher(TeacherDto dto)
        {
            var teacher = await _teacherRepository.GetInfoById(dto.TeacherId);
            if (teacher == null)
                throw new Exception("Teacher not Found");

            _teacherRepository.RemoveTeacher(teacher);
            await _teacherRepository.SaveChangesAsync();
            return true;

        }
    }
}
