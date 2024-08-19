using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlayList
    {
        Task<Playlist> CreatePlaylists(Playlist playlists);
        Task<Playlist> GetPlaylistsById(int id);
        Task<List<Playlist>> GetAllPlaylists();
        Task<Playlist> UpdatePlaylists(int id, Playlist playlists);
        Task DeletePlaylists(int id);
        Task<PlaylistSong> Add_To_Playlist(int songID, int playlistID);
    }
}
