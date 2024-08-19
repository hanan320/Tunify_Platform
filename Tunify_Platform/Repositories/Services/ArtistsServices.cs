using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistsServices : IArtists
    {
        private readonly TunifyDbContext _context;

        public ArtistsServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task DeleteArtists(int id)
        {
            var artist = await GetArtistById(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }
        }

        public async Task<List<Artist>> GetAllArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }
            return artist;
        }

        public async Task<Artist> UpdateArtists(int id, Artist artist)
        {
            var exsitingArtist = await _context.Artists.FindAsync(id);
            exsitingArtist = artist;
            await _context.SaveChangesAsync();
            return artist;
        }
      

    }
}