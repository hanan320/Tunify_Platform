using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISong
    {
        Task<Song> CreateSong(Song song);
        Task<Song> GetSongById(int id);
        Task<List<Song>> GetAllSongs();
        Task<Song> UpdateSong(int id, Song song);
        Task DeleteSong(int id);
        Task<List<Song>> GetAllSongsFromArtist(int artistID);

        Task<List<Song>> GetAllSongsFromPlaylist(int playlistID);
    }
}
