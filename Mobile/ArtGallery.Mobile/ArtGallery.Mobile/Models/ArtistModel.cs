using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ArtGallery.Mobile.Models
{
    public class ArtistModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;


        [JsonPropertyName("biography")]
        public string Biography { get; set; } = string.Empty;


        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;


        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
