using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Repositories;

namespace ArtGallery.BLL.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IRepository<Favorite> _favoriteRepository;

    public FavoriteService(IRepository<Favorite> favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task ToggleFavoriteAsync(int userId, int artworkId)
    {
        var existing = await _favoriteRepository.FindAsync(f =>
            f.UserId == userId && f.ArtworkId == artworkId);

        if (existing != null)
        {
            await _favoriteRepository.DeleteAsync(existing.Id);
        }
        else
        {
            await _favoriteRepository.AddAsync(new Favorite
            {
                UserId = userId,
                ArtworkId = artworkId
            });
        }
    }

    public async Task<IEnumerable<int>> GetUserFavoriteArtworkIdsAsync(int userId)
    {
        var favorites = await _favoriteRepository.GetAllAsync();
        return favorites.Where(f => f.UserId == userId).Select(f => f.ArtworkId);
    }
}