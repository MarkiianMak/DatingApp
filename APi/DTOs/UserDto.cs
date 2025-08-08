using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APi.DTOs
{
    public class UserDto
    {
        public required string Id { get; set; } = string.Empty;

        public required string Name { get; set; } = string.Empty;

        public required string Email { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;

        public required string Token { get; set; }
    }
}