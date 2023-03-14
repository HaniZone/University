using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Application.Services;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectUnitCourseController : ControllerBase
    {
        ISelectUnitCourseApplicationService _selectUnitCourseApplicationService;
        public SelectUnitCourseController(ISelectUnitCourseApplicationService selectUnitCourseApplicationService)
        {
            _selectUnitCourseApplicationService = selectUnitCourseApplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SelectUnitCourseDto dto)
        {
            var selectUnitCourse = await _selectUnitCourseApplicationService.NewSelectUnitCourse(dto);
            return Ok(selectUnitCourse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int pagenumber,int  pagesize)
        {
            var UnitCoursesList = await _selectUnitCourseApplicationService.UnitCoursesList(pagenumber, pagesize);
            return Ok(UnitCoursesList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetCapabilityById(SelectUnitCourseDto dto)
        {
            var capability = await _selectUnitCourseApplicationService.GetCapabilityById(dto);
            return Ok(capability);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SelectUnitCourseDto dto)
        {
            if (dto.SelectUnitCourseId == null)
                return BadRequest();

            await _selectUnitCourseApplicationService.UpdateSelectUnitCourse(dto);
            return Ok();
        }
    }
}
