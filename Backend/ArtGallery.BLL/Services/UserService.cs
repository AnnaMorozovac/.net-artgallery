using AutoMapper;
using ArtGallery.BLL.DTOs;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Repositories;

namespace ArtGallery.BLL.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.FindAsync(u =>
            u.Username == loginDto.Username && u.Password == loginDto.Password);

        return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> RegisterAsync(CreateUserDto dto)
    {
        var entity = _mapper.Map<User>(dto);
        await _userRepository.AddAsync(entity);
        return _mapper.Map<UserDto>(entity);
    }

    public async Task<UserDto?> GetByIdAsync(int id) =>
        _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(id));
}