using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tunify_Platform.Models
{
    public class Song
    {
        [Key]
        public int SongsId { get; set; }

        [Required]
        public int Artist_Id { get; set; }
        [ForeignKey("Artist_Id")]
        public Artist Artist { get; set; }

        [Required]
        public int Album_Id { get; set; }
        [ForeignKey("Album_Id")]
        public Album Album { get; set; }


        public string Title { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<PlaylistSong>playlistSongs { get; set; } = new List<PlaylistSong>();
    }
}
