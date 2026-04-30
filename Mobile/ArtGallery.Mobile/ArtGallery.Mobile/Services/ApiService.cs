using System.Net.Http.Json;
using ArtGallery.Mobile.Models;
using System.Diagnostics;

namespace ArtGallery.Mobile.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task ShowError(string message)
    {
        await Shell.Current.DisplayAlert("Network error", message, "OK");
    }

    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryModel>>("api/categories") ?? new List<CategoryModel>();
        }
        catch (HttpRequestException ex)
        {
            await ShowError($"Failed to load categories: {ex.Message}");
            return new List<CategoryModel>();
        }
    }

    public async Task<IEnumerable<ExhibitionModel>> GetExhibitionsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExhibitionModel>>("api/exhibitions") ?? new List<ExhibitionModel>();
        }
        catch (HttpRequestException ex)
        {
            await ShowError($"Error loading exhibitions: {ex.Message}");
            return new List<ExhibitionModel>();
        }
    }

    public async Task<IEnumerable<ArtistModel>> GetArtistsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ArtistModel>>("api/artists") ?? new List<ArtistModel>();
        }
        catch (HttpRequestException ex)
        {
            await ShowError("Connection problem when retrieving artist list.");
            return new List<ArtistModel>();
        }
    }

    public async Task<ArtistModel?> GetArtistByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<ArtistModel>($"api/artists/{id}");
        }
        catch (HttpRequestException)
        {
            await ShowError("Could not find artist details.");
            return null;
        }
    }

    public async Task<IEnumerable<ArtworkModel>> GetArtworksAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ArtworkModel>>("api/artworks") ?? new List<ArtworkModel>();
        }
        catch (HttpRequestException)
        {
            await ShowError("Error loading gallery.");
            return new List<ArtworkModel>();
        }
    }

    public async Task<ArtworkModel?> GetArtworkByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<ArtworkModel>($"api/artworks/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<bool> CreateArtworkAsync(ArtworkModel artwork)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/artworks", artwork);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            await ShowError("Failed to save new picture.");
            return false;
        }
    }

    public async Task<bool> UpdateArtworkAsync(ArtworkModel artwork)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/artworks/{artwork.Id}", artwork);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            await ShowError("Error updating picture data.");
            return false;
        }
    }

    public async Task<bool> DeleteArtworkAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/artworks/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            await ShowError("The object could not be deleted.");
            return false;
        }
    }

    public async Task<UserModel?> LoginAsync(string username, string password)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/login", new { username, password });
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<UserModel>();

            await ShowError("Incorrect login or password.");
            return null;
        }
        catch (HttpRequestException)
        {
            await ShowError("The authorization server is unavailable.");
            return null;
        }
    }

    public async Task<bool> RegisterAsync(UserModel user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/register", user);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            await ShowError("Registration error. Check your connection.");
            return false;
        }
    }

    public async Task<UserModel?> GetUserByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<UserModel>($"api/users/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<bool> UpdateUserAsync(UserModel user)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/{user.Id}", user);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            await ShowError("Failed to update profile.");
            return false;
        }
    }

    public async Task<List<int>> GetUserFavoriteIdsAsync(int userId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<int>>($"api/favorites/user/{userId}") ?? new List<int>();
        }
        catch (HttpRequestException)
        {
            return new List<int>();
        }
    }

    public async Task<bool> ToggleLikeAsync(int userId, int artworkId)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/favorites/toggle", new { userId, artworkId });
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }
}