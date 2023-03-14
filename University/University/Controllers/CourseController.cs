using Microsoft.AspNetCore.Mvc;
using University.Application.Services.Interface;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseApplicationService _courseApplicationService;
        public CourseController(ICourseApplicationService courseApplicationService)
        {
            _courseApplicationService = courseApplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CourseDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CourseName) & dto.Unit == null)
                return BadRequest("Invalid input");

            var result = await _courseApplicationService.NewCourse(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pagenumber, int pagesize)
        {
            var coursesList = await _courseApplicationService.CoursesList(pagenumber, pagesize);
            return Ok(coursesList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(CourseDto dto)
        {
            var course = await _courseApplicationService.GetCourseById(dto);
            return Ok(course);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CourseDto dto)
        {
            if (dto.CourseId == null)
                return BadRequest();

            await _courseApplicationService.UpdateCourse(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CourseDto dto)
        {
            if (dto.CourseId == null)
                return BadRequest();

            await _courseApplicationService.DeleteCourse(dto);
            return Ok();
        }
    }
}
