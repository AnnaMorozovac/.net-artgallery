using AutoMapper;
using ArtGallery.BLL.DTOs;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Repositories;

namespace ArtGallery.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync() => _mapper.Map<IEnumerable<CategoryDto>>(await _repository.GetAllAsync());
    public async Task<CategoryDto?> GetByIdAsync(int id) => _mapper.Map<CategoryDto>(await _repository.GetByIdAsync(id));
    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var entity = _mapper.Map<Category>(dto);
        await _repository.AddAsync(entity);
        return _mapper.Map<CategoryDto>(entity);
    }
    public async Task UpdateAsync(int id, UpdateCategoryDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null) { _mapper.Map(dto, entity); await _repository.UpdateAsync(entity); }
    }
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}