﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtists _artists;

        public ArtistsController(IArtists context)
        {
            _artists = context;
        }

        // GET: api/Artists
        [Route("/artist/GetAllArtists")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            var artists = await _artists.GetAllArtists();
            return Ok(artists);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtists(int id)
        {
            var artist = await _artists.GetArtistById(id);

            if (artist == null)
            {
                return NotFound($"Artist [{id}] not found.");
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtists(int id, Artist artists)
        {
            var updatedArtist = await _artists.UpdateArtists(id, artists);

            if (updatedArtist == null)
            {
                return NotFound($"Artist [{id}] not found.");
            }

            return Ok(updatedArtist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtists(Artist artists)
        {
            var newArtist = await _artists.CreateArtist(artists);
            return Ok(newArtist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtists(int id)
        {
            var artist = await _artists.GetArtistById(id);

            if (artist == null)
            {
                return NotFound($"Artist [{id}] not found.");
            }

            await _artists.DeleteArtists(id);
            return NoContent();
        }

        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<Song> AddSongToArtist(int songID, int artistID)
        {

            return await _artists.AddSongToArtist(songID, artistID);

        }



    }
}
