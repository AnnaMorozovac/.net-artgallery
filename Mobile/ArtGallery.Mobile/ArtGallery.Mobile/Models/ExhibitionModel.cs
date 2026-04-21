using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Globalization;

namespace ArtGallery.Mobile.Models
{
    public class ExhibitionModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;


        [JsonPropertyName("startDate")]
        public DateTime StartDate {  get; set; }


        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }


        [JsonPropertyName("location")]
        public string Location {  get; set; } = string.Empty;
    }
}
