using ArtGallery.BLL.DTOs;
using ArtGallery.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto dto)
    {
        var result = await userService.LoginAsync(dto);
        return result == null ? Unauthorized("Wrong login or password") : Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(CreateUserDto dto)
    {
        var result = await userService.RegisterAsync(dto);
        return Ok(result);
    }
}