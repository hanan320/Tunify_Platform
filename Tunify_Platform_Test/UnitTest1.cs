using Microsoft.EntityFrameworkCore;
using Moq;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform_Test
{
    public class UnitTest1
    {
      
        
            private readonly SongServices _songServices;
            private readonly Mock<TunifyDbContext> _mockContext;

            public UnitTest1()
            {
                _mockContext = new Mock<TunifyDbContext>(new DbContextOptions<TunifyDbContext>());
                _songServices = new SongServices(_mockContext.Object);
            }

            [Fact]
            public async Task GetAllSongsFromPlaylist_ReturnsCorrectSongs()
            {
                // Arrange
                var playlistId = 1;

                var songs = new List<Song>
        {
            new Song { SongsId = 1, Title = "Imagine", Artist_Id = 1, Album_Id = 1, Duration = new TimeSpan(0, 3, 15), Genre = "Pop" },
            new Song { SongsId = 2, Title = "Imagine2", Artist_Id = 1, Album_Id = 1, Duration = new TimeSpan(0, 3, 15), Genre = "Pop" }
        };

                var playlistSongs = new List<PlaylistSong>
        {
            new PlaylistSong { PlaylistSongsID = 1, Playlist_Id = playlistId, Song_Id = 1 },
            new PlaylistSong { PlaylistSongsID = 2, Playlist_Id = playlistId, Song_Id = 2 }
        };

                var queryableSongs = songs.AsQueryable();
                var queryablePlaylistSongs = playlistSongs.AsQueryable();

                var mockSongsDbSet = new Mock<DbSet<Song>>();
                mockSongsDbSet.As<IQueryable<Song>>().Setup(m => m.Provider).Returns(queryableSongs.Provider);
                mockSongsDbSet.As<IQueryable<Song>>().Setup(m => m.Expression).Returns(queryableSongs.Expression);
                mockSongsDbSet.As<IQueryable<Song>>().Setup(m => m.ElementType).Returns(queryableSongs.ElementType);
                mockSongsDbSet.As<IQueryable<Song>>().Setup(m => m.GetEnumerator()).Returns(queryableSongs.GetEnumerator());

                var mockPlaylistSongsDbSet = new Mock<DbSet<PlaylistSong>>();
                mockPlaylistSongsDbSet.As<IQueryable<PlaylistSong>>().Setup(m => m.Provider).Returns(queryablePlaylistSongs.Provider);
                mockPlaylistSongsDbSet.As<IQueryable<PlaylistSong>>().Setup(m => m.Expression).Returns(queryablePlaylistSongs.Expression);
                mockPlaylistSongsDbSet.As<IQueryable<PlaylistSong>>().Setup(m => m.ElementType).Returns(queryablePlaylistSongs.ElementType);
                mockPlaylistSongsDbSet.As<IQueryable<PlaylistSong>>().Setup(m => m.GetEnumerator()).Returns(queryablePlaylistSongs.GetEnumerator());

                _mockContext.Setup(c => c.Songs).Returns(mockSongsDbSet.Object);
                _mockContext.Setup(c => c.PlaylistSongs).Returns(mockPlaylistSongsDbSet.Object);

                // Act
                var result = await _songServices.GetAllSongsFromPlaylist(playlistId);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, s => s.SongsId == 1 && s.Title == "Imagine");
                Assert.Contains(result, s => s.SongsId == 2 && s.Title == "Imagine2");
            }
        }
    
}