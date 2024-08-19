using System.ComponentModel.DataAnnotations;

namespace Tunify_Platform.Models
{
    public class Artist
    {
        [Key]
        public int ArtistsId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
