namespace ArtGallery.BLL.DTOs;

public class CreateArtworkDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CreationYear { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int ArtistId { get; set; }
    public int CategoryId { get; set; }
}