using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University.Application.Dtos;
using University.Core.Models;
using University.Core.Repositories.Interfaces;
using University.Infrastructure.Repositories;

namespace University.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _userRepository;

        public UserApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<LoginViewModelDto> Login(LoginDto dto)
        {
            var user = await _userRepository.GetUserbyUsername(dto.UserName);
            if (user == null)
                return new LoginViewModelDto()
                {
                    Success = false,
                    Message = "incorrect Username "
                };

            if (!user.Password.Equals(dto.Password))
                return new LoginViewModelDto()
                {
                    Success = false,
                    Message = "incorrect password"
                };

            var token = GenerateToken(user);
            return new LoginViewModelDto()
            {
                Success = true,
                Token = token
            };
        }
        

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HaniehMolavi"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role,"admin"),
                new Claim(ClaimTypes.Role,"user"),
            };

            var token = new JwtSecurityToken("localhost",
                "localhost",
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
