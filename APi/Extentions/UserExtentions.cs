using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APi.DTOs;
using APi.Models;
using APi.Interfaces;

namespace APi.Extentions
{
    public static class UserExtentions
    {
        public static UserDto ToDto(this User user, ITokenService tokenService)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Token = tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}
