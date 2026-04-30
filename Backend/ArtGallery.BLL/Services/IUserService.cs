using ArtGallery.BLL.DTOs;

namespace ArtGallery.BLL.Services;

public interface IUserService
{
    Task<UserDto?> LoginAsync(LoginDto loginDto);
    Task<UserDto> RegisterAsync(CreateUserDto createUserDto);
    Task<UserDto?> GetByIdAsync(int id);
}