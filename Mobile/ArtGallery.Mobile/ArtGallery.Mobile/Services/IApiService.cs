using ArtGallery.Mobile.Models;

namespace ArtGallery.Mobile.Services;

public interface IApiService
{
    Task<IEnumerable<CategoryModel>> GetCategoriesAsync();


    Task<IEnumerable<ExhibitionModel>> GetExhibitionsAsync();


    Task<IEnumerable<ArtistModel>> GetArtistsAsync();
    Task<ArtistModel?> GetArtistByIdAsync(int id);


    Task<IEnumerable<ArtworkModel>> GetArtworksAsync();
    Task<ArtworkModel?> GetArtworkByIdAsync(int id);
    Task<bool> CreateArtworkAsync(ArtworkModel artwork);
    Task<bool> UpdateArtworkAsync(ArtworkModel artwork);
    Task<bool> DeleteArtworkAsync(int id);


    Task<UserModel?> LoginAsync(string username, string password);
    Task<bool> RegisterAsync(UserModel user);


    Task<UserModel?> GetUserByIdAsync(int id); 
    Task<bool> UpdateUserAsync(UserModel user);


    Task<List<int>> GetUserFavoriteIdsAsync(int userId);
    Task<bool> ToggleLikeAsync(int userId, int artworkId);
}