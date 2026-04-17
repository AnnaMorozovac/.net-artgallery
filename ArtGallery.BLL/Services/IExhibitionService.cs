using ArtGallery.BLL.DTOs;

namespace ArtGallery.BLL.Services;
public interface IExhibitionService 
{ 
    Task<IEnumerable<ExhibitionDto>> GetAllAsync(); 
    Task<ExhibitionDto?> GetByIdAsync(int id); 
    Task<ExhibitionDto> CreateAsync(CreateExhibitionDto dto); 
    Task UpdateAsync(int id, UpdateExhibitionDto dto); 
    Task DeleteAsync(int id); 
}