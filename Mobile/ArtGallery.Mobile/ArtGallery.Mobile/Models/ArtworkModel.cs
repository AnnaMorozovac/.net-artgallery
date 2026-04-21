using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ArtGallery.Mobile.Models
{
    public class ArtworkModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;


        [JsonPropertyName("description")]   
        public string Description { get; set; } = string.Empty;


        [JsonPropertyName("creationYear")]
        public int CreationYear { get; set; }


        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;


        [JsonPropertyName("price")]
        public int Price { get; set; }


        [JsonPropertyName("artistId")]
        public int ArtistId { get; set; }


        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

    }
}
