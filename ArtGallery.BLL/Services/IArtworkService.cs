using ArtGallery.BLL.DTOs;

namespace ArtGallery.BLL.Services;

public interface IArtworkService
{
    Task<IEnumerable<ArtworkDto>> GetAllAsync();
    Task<ArtworkDto?> GetByIdAsync(int id);
    Task<ArtworkDto> CreateAsync(CreateArtworkDto dto);
    Task UpdateAsync(int id, UpdateArtworkDto dto);
    Task DeleteAsync(int id);
}