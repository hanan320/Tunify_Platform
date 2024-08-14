﻿using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<Artists> CreateArtist(Artists artist);
        Task<Artists> GetArtistById(int id);
        Task<List<Artists>> GetAllArtists();
        Task<Artists> UpdateArtists(int id, Artists artist);
        Task DeleteArtists(int id);
    }
}
