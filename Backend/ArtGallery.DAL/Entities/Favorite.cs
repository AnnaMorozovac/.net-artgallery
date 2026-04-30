namespace ArtGallery.DAL.Entities;

public class Favorite
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int ArtworkId { get; set; }
    public Artwork Artwork { get; set; } = null!;
}