using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<Artist> CreateArtist(Artist artist);
        Task<Artist> GetArtistById(int id);
        Task<List<Artist>> GetAllArtists();
        Task<Artist> UpdateArtists(int id, Artist artist);
        Task DeleteArtists(int id);
        Task<Song> AddSongToArtist(int songID, int artistID);

    }
}
