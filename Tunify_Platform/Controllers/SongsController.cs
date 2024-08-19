using System;
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
    public class SongsController : ControllerBase
    {
        private readonly ISong _song;

        public SongsController(ISong context)
        {
            _song = context;
        }

        // GET: api/Songs
        [Route("/songs/GetAllSongs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return Ok(await _song.GetAllSongs());
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSongs(int id)
        {
            var song = await _song.GetSongById(id);

            if (song == null)
            {
                return NotFound($"Song [{id}] not found.");
            }

            return Ok(song);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Song songs)
        {
            var updatedSong = await _song.UpdateSong(id, songs);
            //Check the user
            if (updatedSong == null)
            {
                return NotFound($"User [{id}] not found.");
            }
            return Ok(updatedSong);
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSongs(Song songs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newSong = await _song.CreateSong(songs);
            return CreatedAtAction(nameof(GetSongs), new { id = newSong.SongsId }, newSong);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongs(int id)
        {
            var song = await _song.GetSongById(id);
            if (song == null)
            {
                return NotFound($"Song [{id}] not found");
            }

            await _song.DeleteSong(id);
            return NoContent();
        }

        [HttpGet("playlists/{playlistId}/songs")]
        public async Task<List<Song>> getAllSongsFromPlaylist(int playlistId)
        {
            return await _song.GetAllSongsFromPlaylist(playlistId);

        }

        [HttpGet("/artistID")]
        public async Task<List<Song>> getAllSongsFromArtist(int artistID)
        {
            return await _song.GetAllSongsFromArtist(artistID);
        }


    }
}
