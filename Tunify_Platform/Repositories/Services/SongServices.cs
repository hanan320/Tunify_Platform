using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongServices : ISong
    {
        private readonly TunifyDbContext _context;

        public SongServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Song> CreateSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task DeleteSong(int id)
        {
            var getSong = await GetSongById(id);
            _context.Songs.Remove(getSong);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Song>> GetAllSongs()
        {
            var allSongs = await _context.Songs.ToListAsync();
            return allSongs;
        }

        public async Task<Song> GetSongById(int id)
        {
            var specificSong = await _context.Songs.FindAsync(id);
            return specificSong;
        }

        public async Task<Song> UpdateSong(int id, Song song)
        {
            var exsitingSong = await _context.Songs.FindAsync(id);
            exsitingSong = song;
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<List<Song>> GetAllSongsFromArtist(int playlistId)
        {
            return await _context.PlaylistSongs
            .Where(ps => ps.Playlist_Id == playlistId)
            .Select(ps => ps.Song)
            .ToListAsync();


        }

        public async Task<List<Song>> GetAllSongsFromPlaylist(int artistID)
        {
            return await _context.Songs.Where(
                s => s.Artist_Id == artistID)
                .ToListAsync();
        }
    }
}
