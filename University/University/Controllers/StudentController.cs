using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Application.Services.Interface;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentApplicationService _studentApplicationService;
        public StudentController(IStudentApplicationService studentApplicationService )
        {
            _studentApplicationService = studentApplicationService;

        }
        [HttpPost]

        public async Task<IActionResult> Post(StudentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name) & string.IsNullOrWhiteSpace(dto.LastName))
                return BadRequest("Invalid input");


            var result = await _studentApplicationService.NewStudent(dto);
            return Ok(result);
        }

        [HttpGet ]
        public async Task<IActionResult> GetAll(int pagenumber , int pagesize)
        {
            var studentsList = await _studentApplicationService.StudentsList(pagenumber , pagesize);
            return Ok(studentsList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(StudentDto dto)
        {
            var student = await _studentApplicationService.GetStudentById(dto);
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> Put(StudentDto dto)
        {
            if (dto.SudentId == null)
                return BadRequest();

            await _studentApplicationService.UpdateStudentInfo(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(StudentDto dto)
        {
            if (dto.SudentId == null)
                return BadRequest();

            await _studentApplicationService.DeleteStudent(dto);
            return Ok();
        }
    }
}
