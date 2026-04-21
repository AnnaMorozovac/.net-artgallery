using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.DAL.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Biography { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
    }
}
