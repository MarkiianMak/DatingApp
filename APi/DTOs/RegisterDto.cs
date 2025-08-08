using System;

namespace APi.DTOs;

using System.ComponentModel.DataAnnotations;

public class RegisterDto
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = "";
}
