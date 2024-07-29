using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface IUserService
{


    public IEnumerable<UserReadDto> FindAll();
    public UserReadDto? FindOne(Guid id);
    public string? Login(UserLogInDto user);
    public UserReadDto? SignUp(UserCreateDto user);
    public bool DeleteOne(Guid id);
    public UserReadDto? UpdateOne(Guid id, UserUpdateDto updatedUser);
    public UserReadDto? UpdateRole(Guid id, UserUpdateRoleDto updatedUser);

}
