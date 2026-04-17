using ArtGallery.BLL.DTOs;

namespace ArtGallery.BLL.Services;
public interface IArtistService 
{ 
    Task<IEnumerable<ArtistDto>> GetAllAsync(); 
    Task<ArtistDto?> GetByIdAsync(int id); 
    Task<ArtistDto> CreateAsync(CreateArtistDto dto); 
    Task UpdateAsync(int id, UpdateArtistDto dto); 
    Task DeleteAsync(int id); 
}