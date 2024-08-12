using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
namespace Tunify_Platform.Data
{
    public class TunifyDbContext :DbContext
    {
        public TunifyDbContext (DbContextOptions options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscripions> Subscripions { get; set; }

        public DbSet<Songs> Songs { get; set; }

        public DbSet<Playlists> playlists { get; set; }

        public DbSet<PlaylistSongs> playlistSongs { get; set; }

        public DbSet<Artists> Artists { get; set; }

        public DbSet<Albums> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "hanan",
                    Email = "hanan1@gmail.com",
                    Join_Date = "1-1-1999",
                    Subscription_ID = 1,
                },
                new User
                {
                    UserId = 2,
                    UserName = "reem",
                    Email = "reem2@gmail.com",
                    Join_Date = "4-4-2004",
                    Subscription_ID = 2,
                },
                new User
                {
                    UserId = 3,
                    UserName = "haya",
                    Email = "haya3@gmail.com",
                    Join_Date = "1-8-2008",
                    Subscription_ID = 3,
                }
             
                );

            modelBuilder.Entity<Songs>().HasData(
                new Songs{ 
                    Album_Id = 2,
                    SongsId = 5,
                    Artist_Id = 3,
                    Title = "Sunset",
                    Duration = "4:15m",
                    Genre = "Pop"
                }, new Songs
                {
                    Album_Id = 2,
                    SongsId = 6,
                    Artist_Id = 4,
                    Title = "Midnight Drive",
                    Duration = "3:45m",
                    Genre = "Rock"
                }, new Songs
                {
                    Album_Id = 3,
                    SongsId = 7,
                    Artist_Id = 5,
                    Title = "Eternal Flame",
                    Duration = "5:00m",
                    Genre = "Ballad"
                }
                );

            modelBuilder.Entity<Playlists>().HasData(
                new Playlists
                {
                    PlaylistsId = 3,
                    User_Id = 2,
                    Created_Date = "15-8-2024",
                    Playlists_Name = "Summer Vibes"
                },
                new Playlists
                {
                    PlaylistsId = 4,
                    User_Id = 2,
                    Created_Date = "30-8-2024",
                    Playlists_Name = "Chill Beats"
                },
                new Playlists
                {
                    PlaylistsId = 5,
                    User_Id = 3,
                    Created_Date = "12-9-2024",
                    Playlists_Name = "Workout Tunes"
                }
                );
        }
    }

}
