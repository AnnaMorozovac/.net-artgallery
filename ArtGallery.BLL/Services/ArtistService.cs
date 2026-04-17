using AutoMapper;
using ArtGallery.BLL.DTOs;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Repositories;

namespace ArtGallery.BLL.Services;

public class ArtistService : IArtistService
{
    private readonly IRepository<Artist> _repository;
    private readonly IMapper _mapper;

    public ArtistService(IRepository<Artist> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArtistDto>> GetAllAsync() => _mapper.Map<IEnumerable<ArtistDto>>(await _repository.GetAllAsync());
    public async Task<ArtistDto?> GetByIdAsync(int id) => _mapper.Map<ArtistDto>(await _repository.GetByIdAsync(id));
    public async Task<ArtistDto> CreateAsync(CreateArtistDto dto)
    {
        var entity = _mapper.Map<Artist>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<ArtistDto>(entity);
    }
    public async Task UpdateAsync(int id, UpdateArtistDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null) { _mapper.Map(dto, entity); await _repository.UpdateAsync(entity); }
    }
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}