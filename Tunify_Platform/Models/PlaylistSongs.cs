namespace Tunify_Platform.Models
{
    public class PlaylistSong
    {
        public int PlaylistSongsID { get; set; }

        public int Song_Id { get; set; }
        public Song Song { get; set; }


        public int Playlist_Id { get; set; }
        public Playlist Playlists { get; set; }

       
    }
}
