using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tunify_Platform.Models
{
    
    public class Playlist
    {
        [Key]
        public int PlaylistsId { get; set; }

        public int User_Id { get; set; }
        public User User { get; set; }

        public string Playlists_Name { get; set; }
        public string Created_Date { get; set; }

        public ICollection<PlaylistSong> playlistSongs { get; set; }=new List<PlaylistSong>();
    }
}
