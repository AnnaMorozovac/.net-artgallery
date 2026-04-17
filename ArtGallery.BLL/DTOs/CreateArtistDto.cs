namespace ArtGallery.BLL.DTOs;

public class CreateArtistDto
{
    public string FullName { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}