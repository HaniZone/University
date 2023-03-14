using Microsoft.AspNetCore.Mvc;
using University.Application.Services;
using University.Application.Services.Interface;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectUnitController : ControllerBase
    {
        ISelectUnitApplicationService _selectUnitApplicationService;
        public SelectUnitController(ISelectUnitApplicationService selectUnitApplicationService)
        {
            _selectUnitApplicationService = selectUnitApplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SelectUnitDto dto)
        {
            if (dto.Started == null & dto.Ended == null)
                return BadRequest("Invalid input");

            var result = await _selectUnitApplicationService.NewUnit(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pagenumber, int pagesize)
        {
            var UnitsList = await _selectUnitApplicationService.UnitsList(pagenumber , pagesize);
            return Ok(UnitsList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(SelectUnitDto dto)
        {
            var student = await _selectUnitApplicationService.ShowSelectUnitTimes(dto);
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SelectUnitDto dto)
        {
            if (dto.SelectUnitId == null)
                return BadRequest();

            await _selectUnitApplicationService.UpdateTimes(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(SelectUnitDto dto)
        {
            if (dto.SelectUnitId == null)
                return BadRequest();

            await _selectUnitApplicationService.TimeOutSelectUnit(dto);
            return Ok();
        }
    }
}
