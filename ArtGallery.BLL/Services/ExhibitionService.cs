using AutoMapper;
using ArtGallery.BLL.DTOs;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Repositories;

namespace ArtGallery.BLL.Services;

public class ExhibitionService : IExhibitionService
{
    private readonly IRepository<Exhibition> _repository;
    private readonly IMapper _mapper;

    public ExhibitionService(IRepository<Exhibition> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExhibitionDto>> GetAllAsync() => _mapper.Map<IEnumerable<ExhibitionDto>>(await _repository.GetAllAsync());
    public async Task<ExhibitionDto?> GetByIdAsync(int id) => _mapper.Map<ExhibitionDto>(await _repository.GetByIdAsync(id));
    public async Task<ExhibitionDto> CreateAsync(CreateExhibitionDto dto)
    {
        var entity = _mapper.Map<Exhibition>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<ExhibitionDto>(entity);
    }
    public async Task UpdateAsync(int id, UpdateExhibitionDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null) { _mapper.Map(dto, entity); await _repository.UpdateAsync(entity); }
    }
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}