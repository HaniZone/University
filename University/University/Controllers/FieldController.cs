using Microsoft.AspNetCore.Mvc;
using University.Application.Services;
using University.Application.Services.Interface;
using University.Core.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        IFieldApplicationService _fieldApplicationService;
        public FieldController(IFieldApplicationService fieldApplicationService)
        {
            _fieldApplicationService = fieldApplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(FieldDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name) & string.IsNullOrWhiteSpace(dto.SectionName))
                return BadRequest("Invalid input");

            var result = await _fieldApplicationService.NewField(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pagenumber, int pagesize)
        {
            var fieldsList = await _fieldApplicationService.FieldsList(pagenumber, pagesize);
            return Ok(fieldsList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(FieldDto dto)
        {
            var field = await _fieldApplicationService.GetFieldById(dto);
            return Ok(field);
        }

        [HttpPut]
        public async Task<IActionResult> Put(FieldDto dto)
        {
            if (dto.FieldId == null)
                return BadRequest();

            await _fieldApplicationService.UpdateFieldInfo(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(FieldDto dto)
        {
            if (dto.FieldId == null)
                return BadRequest();

            await _fieldApplicationService.DeleteField(dto);
            return Ok();
        }
    }
}
