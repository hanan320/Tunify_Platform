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
        public async Task<Playlist> CreatePlaylists(Playlist playlists)
        {
            if (playlists.playlistSongs == null)
            {
                playlists.playlistSongs = new List<PlaylistSong>();
            }

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

        public async Task<List<Playlist>> GetAllPlaylists()
        {
            var allPlaylists = await _context.playlists.ToListAsync();
            return allPlaylists;
        }

        public async Task<Playlist> GetPlaylistsById(int id)
        {
            var specificPlayList = await _context.playlists.FindAsync(id);
            return specificPlayList;
        }

        public async Task<Playlist> UpdatePlaylists(int id, Playlist playList)
        {
            var exsitingPlaylist = await _context.playlists.FindAsync(id);
            exsitingPlaylist = playList;
            await _context.SaveChangesAsync();
            return playList;
        }

        public async Task<PlaylistSong> Add_To_Playlist(int playlistId, int songId)
        {
            var playlistsong = new PlaylistSong();
            playlistsong.Playlist_Id = playlistId;
            playlistsong.Song_Id = songId;

            _context.PlaylistSongs.Add(playlistsong);
            await _context.SaveChangesAsync();
            return playlistsong;
        }

    }
}
