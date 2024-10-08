using System.ComponentModel.DataAnnotations;
using Anime_figures_backend.src.Enums;

namespace Anime_figures_backend.src.DTOs;

public class UserReadDto
{
    public Guid Id { get; set; }

    public string Role { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }
}

public class UserCreateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
}

public class UserLogInDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public class UserUpdateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
}
public class UserUpdateRoleDto
{
    public Role Role { get; set; }
}
