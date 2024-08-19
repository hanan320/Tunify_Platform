using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Tunify_Platform.Data
{
    public class TunifyDbContext : DbContext
    {
        public TunifyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscripion> Subscriptions { get; set; }
        public DbSet<Playlist> playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
           .ToTable("playlists")
           .HasKey(p => p.PlaylistsId);

            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.User_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            modelBuilder.Entity<Album>()
            .HasKey(a => a.Albums_Id);


            modelBuilder.Entity<Song>()
    .HasOne(s => s.Artist)
    .WithMany(a => a.Songs)
    .HasForeignKey(s => s.Artist_Id)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.Album_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaylistSong>()
                      .HasKey(ps => ps.PlaylistSongsID);

                  modelBuilder.Entity<PlaylistSong>()
                      .HasOne(ps => ps.Playlists)
                      .WithMany(p => p.playlistSongs)
                      .HasForeignKey(ps => ps.Playlist_Id);

                  modelBuilder.Entity<PlaylistSong>()
                      .HasOne(ps => ps.Song)
                      .WithMany(s => s.playlistSongs)
                      .HasForeignKey(ps => ps.Song_Id);



                  modelBuilder.Entity<Subscripion>()
                      .HasMany(s => s.Users)
                      .WithOne(u => u.Subscription)
                      .HasForeignKey(u => u.Subscription_ID);

                  modelBuilder.Entity<Subscripion>()
                      .Property(s => s.Price)
                      .HasPrecision(18, 2);



                  modelBuilder.Entity<User>()
                      .HasMany(u => u.Playlists)
                      .WithOne(p => p.User)
                      .HasForeignKey(p => p.User_Id);



                  modelBuilder.Entity<Artist>()
                      .HasMany(a => a.Albums)
                      .WithOne(al => al.Artist)
                      .HasForeignKey(al => al.Artist_Id);

                  modelBuilder.Entity<Artist>()
                      .HasMany(a => a.Songs)
                      .WithOne(s => s.Artist)
                      .HasForeignKey(s => s.Artist_Id);



                  modelBuilder.Entity<Album>()
                      .HasMany(al => al.Songs)
                      .WithOne(s => s.Album)
                      .HasForeignKey(s => s.Album_Id)
                      .OnDelete(DeleteBehavior.Restrict);



                 



                  modelBuilder.Entity<User>().HasData(
                      new User { UserId = 1, UserName = "hanan", Email = "hanan@gmail.com", Join_Date = "1999-01-01", Subscription_ID = 1 },
                      new User { UserId = 2, UserName = "reem", Email = "user2@example.com", Join_Date = "2000-01-01", Subscription_ID = 1 }
                  );

                  modelBuilder.Entity<Subscripion>().HasData(
                      new Subscripion { SubscripionsId = 1, Subscripions_Type = "Premium", Price = 10.0m },
                      new Subscripion { SubscripionsId = 2, Subscripions_Type = "Premium", Price = 10.0m }
                  );

                  modelBuilder.Entity<Song>().HasData(
                      new Song { SongsId = 1, Title = "Imagine", Artist_Id = 1, Album_Id = 1, Duration = new TimeSpan(0, 3, 15), Genre = "Pop" },
                      new Song { SongsId = 2, Title = "Imagine2", Artist_Id = 1, Album_Id = 1, Duration = new TimeSpan(0, 3, 15), Genre = "Pop" }
                  );

                  modelBuilder.Entity<Artist>().HasData(
                      new Artist { ArtistsId = 1, Name = "John Lennon", Bio = "An English singer, songwriter, and peace activist, known for his role in The Beatles and solo career." }
                  );

                  modelBuilder.Entity<Album>().HasData(
                      new Album { Albums_Id = 1, Album_Name = "Imaginess", Release_Date = "1971- 09- 09", Artist_Id = 1 }
                  );

                  modelBuilder.Entity<Playlist>().HasData(
                      new Playlist { PlaylistsId = 1, User_Id = 1, Playlists_Name = "myplaylist", Created_Date = "1971-09-09" },
                      new Playlist { PlaylistsId = 2, User_Id = 2, Playlists_Name = "myplaylist2", Created_Date = "1971-09-09" }
                  );

                  modelBuilder.Entity<PlaylistSong>().HasData(
                      new PlaylistSong { PlaylistSongsID = 1, Playlist_Id = 1, Song_Id = 1 },
                      new PlaylistSong { PlaylistSongsID = 2, Playlist_Id = 1, Song_Id = 2 },
                      new PlaylistSong { PlaylistSongsID = 3, Playlist_Id = 2, Song_Id = 1 }
                  );
         
        }

}


}
