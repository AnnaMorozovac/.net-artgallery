using System.Text.Json.Serialization;

namespace ArtGallery.Mobile.Models
{
    public class FavoriteModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("artworkId")]
        public int ArtworkId { get; set; }
    }
}