﻿using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistsServices : IPlayList
    {
        private readonly TunifyDbContext _context;

        public PlaylistsServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Playlists> CreatePlaylists(Playlists playlists)
        {
            _context.playlists.Add(playlists);
            await _context.SaveChangesAsync();
            return playlists;
        }

        public async Task DeletePlaylists(int id)
        {
            var getPlayList = await GetPlaylistsById(id);
            _context.playlists.Remove(getPlayList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlists>> GetAllPlaylists()
        {
            var allPlaylists = await _context.playlists.ToListAsync();
            return allPlaylists;
        }

        public async Task<Playlists> GetPlaylistsById(int id)
        {
            var specificPlayList = await _context.playlists.FindAsync(id);
            return specificPlayList;
        }

        public async Task<Playlists> UpdatePlaylists(int id, Playlists playList)
        {
            var exsitingPlaylist = await _context.playlists.FindAsync(id);
            exsitingPlaylist = playList;
            await _context.SaveChangesAsync();
            return playList;
        }

    }
}
