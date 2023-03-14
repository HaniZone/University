using Microsoft.AspNetCore.Mvc;
using University.Application.Services.Interface;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        IStudentCourseApplicationService _studentCourseApplicationService;
        public StudentCourseController(IStudentCourseApplicationService studentCourseApplicationService)
        {
            _studentCourseApplicationService = studentCourseApplicationService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(StudentCourseDto dto)
        {

            var result = await _studentCourseApplicationService.NewStudentCourse(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pagenumber, int pagesize)
        {
            var lists = await _studentCourseApplicationService.lists(pagenumber, pagesize);
            return Ok(lists);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(StudentCourseDto dto)
        {
            var info = await _studentCourseApplicationService.GetStudentCourseById(dto);
            return Ok(info);
        }

        /*[HttpPut]
        public async Task<IActionResult> Put(StudentCourseDto dto)
        {
            if (dto.Id == null)
                return BadRequest();

            await _studentCourseApplicationService.UpdateStudentInfo(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(StudentDto dto)
        {
            if (dto.SudentId == null)
                return BadRequest();

            await _studentApplicationService.DeleteStudent(dto);
            return Ok();
        }*/
    }
}
