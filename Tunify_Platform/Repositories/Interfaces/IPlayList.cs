﻿using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlayList
    {
        Task<Playlists> CreatePlaylists(Playlists playlists);
        Task<Playlists> GetPlaylistsById(int id);
        Task<List<Playlists>> GetAllPlaylists();
        Task<Playlists> UpdatePlaylists(int id, Playlists playlists);
        Task DeletePlaylists(int id);
    }
}
