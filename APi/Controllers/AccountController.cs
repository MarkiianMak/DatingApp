using APi.Data;
using APi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

using APi.DTOs;
using APi.Interfaces;
using APi.Extentions;

namespace APi.Controllers
{
    public class AccountController(ApplicationDbContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await context.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email is already in use");
            }

            using var hmac = new HMACSHA512();
            var user = new User
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user.ToDto(tokenService);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDTO loginDTO)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == loginDTO.Email);
            if (user == null) return Unauthorized("Invalid email");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid password");
                }
            }

            return user.ToDto(tokenService);
        }
    }
}
