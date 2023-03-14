using University.Core.Models;

namespace University.Application.Dtos
{
    public class LoginDto
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
