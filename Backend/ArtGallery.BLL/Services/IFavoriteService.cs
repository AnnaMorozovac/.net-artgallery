namespace ArtGallery.BLL.Services;

public interface IFavoriteService
{
    Task ToggleFavoriteAsync(int userId, int artworkId);
    Task<IEnumerable<int>> GetUserFavoriteArtworkIdsAsync(int userId);
}