using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.DAL.Entities
{
    public class Artwork
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CreationYear {  get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = null;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null;
    }
}
