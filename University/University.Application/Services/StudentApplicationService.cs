using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Services.Interface;
using University.Core.Models;
using University.Core.Repositories.Interfaces;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class StudentApplicationService : IStudentApplicationService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFieldRepository _fieldRepository;


        public StudentApplicationService(IStudentRepository studentRepository,
            IFieldRepository fieldRepository)
        {
            _studentRepository = studentRepository;
            _fieldRepository = fieldRepository;
        }

        public async Task<int> NewStudent(StudentDto dto)
        {
            var field = await _fieldRepository.GetInfoById(dto.FieldId);
            if (field == null)
                throw new ApplicationException("field not found ");

            var newStudent = new Student(dto.Name, dto.LastName, dto.NationalCode, dto.PhoneNumber, dto.BirthDay, dto.FieldId);
            _studentRepository.AddNewStudent(newStudent);

            await _studentRepository.SaveChangesAsync();
            return newStudent.StudentId;
        }

        public async Task<Student> GetStudentById(StudentDto dto)
        {
            var studentInfo = await _studentRepository.GetInfoById(dto.SudentId);
            return studentInfo;
        }

        public async Task<List<Student>> StudentsList(int pagenumber, int pagesize)
        {
            var studentsList = await _studentRepository.GetAllStudents(pagenumber, pagesize);
            return studentsList;
        }

        public async Task<bool> UpdateStudentInfo(StudentDto dto)
        {
            var student = await _studentRepository.GetInfoById(dto.SudentId);
            if (student == null)
                throw new ApplicationException("Student not found");

            student.Name = dto.Name;
            student.LastName = dto.LastName;
            student.NationalCode = dto.NationalCode;
            student.PhoneNumber = dto.PhoneNumber;
            student.BirthDay = dto.BirthDay;
            student.FieldId = dto.FieldId;

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

        }
    }

}
