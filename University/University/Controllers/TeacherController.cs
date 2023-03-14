using Microsoft.AspNetCore.Mvc;
using University.Application.Services;
using University.Application.Services.Interface;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherApplicationService _teacherApplicationService;
        public TeacherController(ITeacherApplicationService teacherApplicationService)
        {
            _teacherApplicationService = teacherApplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(TeacherDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TeacherName) & string.IsNullOrWhiteSpace(dto.TeacherLastName))
                return BadRequest("Invalid input");

            var result = await _teacherApplicationService.NewTeacher(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pagenumber, int pagesize)
        {
            var teachersList = await _teacherApplicationService.TeachersList(pagenumber, pagesize);
            return Ok(teachersList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Diploma(TeacherDto dto)
        {
            var teacher = await _teacherApplicationService.TeacherDiploma(dto);
            return Ok(teacher);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TeacherDto dto)
        {
            if (dto.TeacherId == null)
                return BadRequest();

            await _teacherApplicationService.UpdateTeacherInfo(dto);    
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(TeacherDto dto)
        {
            if (dto.TeacherId == null)
                return BadRequest();

            await _teacherApplicationService.DeleteTeacher(dto);
            return Ok();
        }
    }
}
