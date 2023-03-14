using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Application.Dtos;
using University.Application.Services;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserApplicationService _userApplicattionService;
        public LoginController(IUserApplicationService userApplicationService)
        {
            _userApplicattionService = userApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _userApplicattionService.Login(dto);
            return Ok(result);
        }
    }
}
