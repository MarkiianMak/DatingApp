using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APi.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string Email { get; set; } = "";
}
