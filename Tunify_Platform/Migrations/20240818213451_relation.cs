using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistSongsId",
                table: "playlistSongs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                columns: new[] { "Song_Id", "Playlist_Id" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 5,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 6,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 7,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Join_Date", "Subscription_ID" },
                values: new object[] { "1-1-1999", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Join_Date", "Subscription_ID" },
                values: new object[] { "4-4-2004", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Join_Date", "Subscription_ID" },
                values: new object[] { "1-8-2008", 3 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 3,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { "15-8-2024", "Summer Vibes", 2 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 4,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { "30-8-2024", "Chill Beats", 2 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 5,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { "12-9-2024", "Workout Tunes", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_Playlist_Id",
                table: "playlistSongs",
                column: "Playlist_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_Songs_Song_Id",
                table: "playlistSongs",
                column: "Song_Id",
                principalTable: "Songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs",
                column: "Playlist_Id",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_Songs_Song_Id",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_Playlist_Id",
                table: "playlistSongs");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistSongsId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                column: "PlaylistSongsId");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 5,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 6,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 7,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Join_Date", "Subscription_ID" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Join_Date", "Subscription_ID" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Join_Date", "Subscription_ID" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 3,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 4,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 5,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { null, null, 0 });
        }
    }
}
