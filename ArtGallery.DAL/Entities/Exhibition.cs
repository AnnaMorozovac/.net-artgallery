using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.DAL.Entities
{
    public class Exhibition
    {
        public int Id {  get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;
    }
}
