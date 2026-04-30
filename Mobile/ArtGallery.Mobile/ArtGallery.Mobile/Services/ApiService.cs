using System.Net.Http.Json; 
using ArtGallery.Mobile.Models;

namespace ArtGallery.Mobile.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryModel>>("api/categories") ?? new List<CategoryModel>();
    }

    public async Task<IEnumerable<ExhibitionModel>> GetExhibitionsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ExhibitionModel>>("api/exhibitions") ?? new List<ExhibitionModel>();
    }

    public async Task<IEnumerable<ArtistModel>> GetArtistsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ArtistModel>>("api/artists") ?? new List<ArtistModel>();
    }

    public async Task<ArtistModel?> GetArtistByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ArtistModel>($"api/artists/{id}");
    }

    public async Task<IEnumerable<ArtworkModel>> GetArtworksAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ArtworkModel>>("api/artworks") ?? new List<ArtworkModel>();
    }

    public async Task<ArtworkModel?> GetArtworkByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ArtworkModel>($"api/artworks/{id}");
    }

    public async Task<bool> CreateArtworkAsync(ArtworkModel artwork)
    {
        var response = await _httpClient.PostAsJsonAsync("api/artworks", artwork); 
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateArtworkAsync(ArtworkModel artwork)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/artworks/{artwork.Id}", artwork);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteArtworkAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/artworks/{id}"); 
        return response.IsSuccessStatusCode;
    }

    public async Task<UserModel?> LoginAsync(string username, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("api/users/login", new { username, password });
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<UserModel>();
        return null;
    }

    public async Task<bool> RegisterAsync(UserModel user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/users/register", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<UserModel?> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<UserModel>($"api/users/{id}");
    }

    public async Task<bool> UpdateUserAsync(UserModel user)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/users/{user.Id}", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<int>> GetUserFavoriteIdsAsync(int userId)
    {
        return await _httpClient.GetFromJsonAsync<List<int>>($"api/favorites/user/{userId}") ?? new List<int>();
    }

    public async Task<bool> ToggleLikeAsync(int userId, int artworkId)
    {
        var response = await _httpClient.PostAsJsonAsync("api/favorites/toggle", new { userId, artworkId });
        return response.IsSuccessStatusCode;
    }
}