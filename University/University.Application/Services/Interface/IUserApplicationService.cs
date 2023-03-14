using Microsoft.VisualStudio.Services.Licensing;
using University.Application.Dtos;
using University.Core.Models;

namespace University.Application.Services
{
    public interface IUserApplicationService
    {
        Task<LoginViewModelDto> Login(LoginDto dto);


    }
}