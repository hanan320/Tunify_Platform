using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class Addseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongsId", "Album_Id", "Artist_Id", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 5, 2, 3, "4:15m", "Pop", "Sunset" },
                    { 6, 2, 4, "3:45m", "Rock", "Midnight Drive" },
                    { 7, 3, 5, "5:00m", "Ballad", "Eternal Flame" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[,]
                {
                    { 1, "hanan1@gmail.com", "1-1-1999", 1, "hanan" },
                    { 2, "reem2@gmail.com", "4-4-2004", 2, "reem" },
                    { 3, "haya3@gmail.com", "1-8-2008", 3, "haya" }
                });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlaylistsId", "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[,]
                {
                    { 3, "15-8-2024", "Summer Vibes", 2 },
                    { 4, "30-8-2024", "Chill Beats", 2 },
                    { 5, "12-9-2024", "Workout Tunes", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 5);
        }
    }
}
