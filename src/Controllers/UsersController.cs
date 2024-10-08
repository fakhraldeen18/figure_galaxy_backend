using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;
public class UsersController : CustomController
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet]
    [Authorize(Roles = "Admin , SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<UserReadDto>> FindAll()
    {
        IEnumerable<UserReadDto> Users = _userService.FindAll();
        return Ok(Users);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserReadDto> FindOne(Guid Id)
    {
        UserReadDto? FindUser = _userService.FindOne(Id);
        if (FindUser == null) return NotFound();
        return Ok(FindUser);
    }

    [HttpPost("signUp")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<UserReadDto> SignUp([FromBody] UserCreateDto NewUser)
    {
        if (NewUser == null) return BadRequest();
        UserReadDto? CreatedUser = _userService.SignUp(NewUser);
        return CreatedAtAction(nameof(SignUp), CreatedUser);
    }

    [HttpPost("logIn")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string?> LogIn([FromBody] UserLogInDto user)
    {
        if (user == null) return BadRequest();
        string? token = _userService.Login(user);
        if (token == null) return BadRequest();
        return Ok(token);
    }

    [HttpPatch("{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserReadDto> UpdateOne(Guid Id, [FromBody] UserUpdateDto UpdateUser)
    {
        UserReadDto? findUser = _userService.FindOne(Id);
        if (findUser == null) return NotFound();
        UserReadDto? UpdatedUser = _userService.UpdateOne(Id, UpdateUser);
        return Accepted(UpdatedUser);
    }

    [HttpPatch("updateRole/{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserReadDto> UpdateRole(Guid Id, [FromBody] UserUpdateRoleDto UserUpdate)
    {
        UserReadDto? FindUser = _userService.FindOne(Id);
        if (FindUser == null) return NotFound();
        UserReadDto? UpdatedRole = _userService.UpdateRole(Id, UserUpdate);
        return Accepted(UpdatedRole);
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid Id)
    {
        var FindUser = _userService.FindOne(Id);
        if (FindUser == null) return NotFound();
        _userService.DeleteOne(Id);
        return NoContent();
    }
}