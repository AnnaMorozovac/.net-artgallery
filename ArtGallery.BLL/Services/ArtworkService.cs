using AutoMapper;
using ArtGallery.BLL.DTOs;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Repositories;

namespace ArtGallery.BLL.Services;

public class ArtworkService : IArtworkService
{
    private readonly IRepository<Artwork> _repository;
    private readonly IMapper _mapper;

    public ArtworkService(IRepository<Artwork> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArtworkDto>> GetAllAsync() => _mapper.Map<IEnumerable<ArtworkDto>>(await _repository.GetAllAsync());
    public async Task<ArtworkDto?> GetByIdAsync(int id) => _mapper.Map<ArtworkDto>(await _repository.GetByIdAsync(id));
    public async Task<ArtworkDto> CreateAsync(CreateArtworkDto dto)
    {
        var entity = _mapper.Map<Artwork>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<ArtworkDto>(entity);
    }
    public async Task UpdateAsync(int id, UpdateArtworkDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null) { _mapper.Map(dto, entity); await _repository.UpdateAsync(entity); }
    }
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}