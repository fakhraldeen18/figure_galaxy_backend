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
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class UserLogInDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
public class UserUpdateRoleDto
{
    public Role Role { get; set; }
}
