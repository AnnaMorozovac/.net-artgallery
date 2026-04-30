using ArtGallery.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController(IFavoriteService favoriteService) : ControllerBase
{
    [HttpPost("toggle")]
    public async Task<IActionResult> Toggle(int userId, int artworkId)
    {
        await favoriteService.ToggleFavoriteAsync(userId, artworkId);
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<int>>> GetUserFavorites(int userId)
    {
        var result = await favoriteService.GetUserFavoriteArtworkIdsAsync(userId);
        return Ok(result);
    }
}