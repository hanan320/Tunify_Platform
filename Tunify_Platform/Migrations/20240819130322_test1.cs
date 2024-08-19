using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_Songs_Song_Id",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs");

            migrationBuilder.DropTable(
                name: "Subscripions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

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

            migrationBuilder.RenameTable(
                name: "playlistSongs",
                newName: "PlaylistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_playlistSongs_Playlist_Id",
                table: "PlaylistSongs",
                newName: "IX_PlaylistSongs_Playlist_Id");

            migrationBuilder.RenameColumn(
                name: "AlbumsId",
                table: "Albums",
                newName: "Albums_Id");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Songs",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistSongsID",
                table: "PlaylistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs",
                column: "PlaylistSongsID");

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscripionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subscripions_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscripionsId);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistsId", "Bio", "Name" },
                values: new object[] { 1, "An English singer, songwriter, and peace activist, known for his role in The Beatles and solo career.", "John Lennon" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscripionsId", "Price", "Subscripions_Type" },
                values: new object[,]
                {
                    { 1, 10.0m, "Premium" },
                    { 2, 10.0m, "Premium" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Join_Date" },
                values: new object[] { "hanan@gmail.com", "1999-01-01" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Join_Date", "Subscription_ID" },
                values: new object[] { "user2@example.com", "2000-01-01", 1 });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlaylistsId", "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[,]
                {
                    { 1, "1971-09-09", "myplaylist", 1 },
                    { 2, "1971-09-09", "myplaylist2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Albums_Id", "Album_Name", "Artist_Id", "Release_Date" },
                values: new object[] { 1, "Imaginess", 1, "1971- 09- 09" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongsId", "Album_Id", "Artist_Id", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 15, 0), "Pop", "Imagine" },
                    { 2, 1, 1, new TimeSpan(0, 0, 3, 15, 0), "Pop", "Imagine2" }
                });

            migrationBuilder.InsertData(
                table: "PlaylistSongs",
                columns: new[] { "PlaylistSongsID", "Playlist_Id", "Song_Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subscription_ID",
                table: "Users",
                column: "Subscription_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Album_Id",
                table: "Songs",
                column: "Album_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Artist_Id",
                table: "Songs",
                column: "Artist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_Song_Id",
                table: "PlaylistSongs",
                column: "Song_Id");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_User_Id",
                table: "playlists",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Artist_Id",
                table: "Albums",
                column: "Artist_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_Artist_Id",
                table: "Albums",
                column: "Artist_Id",
                principalTable: "Artists",
                principalColumn: "ArtistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlists_Users_User_Id",
                table: "playlists",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_Song_Id",
                table: "PlaylistSongs",
                column: "Song_Id",
                principalTable: "Songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_playlists_Playlist_Id",
                table: "PlaylistSongs",
                column: "Playlist_Id",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_Album_Id",
                table: "Songs",
                column: "Album_Id",
                principalTable: "Albums",
                principalColumn: "Albums_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_Artist_Id",
                table: "Songs",
                column: "Artist_Id",
                principalTable: "Artists",
                principalColumn: "ArtistsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_Subscription_ID",
                table: "Users",
                column: "Subscription_ID",
                principalTable: "Subscriptions",
                principalColumn: "SubscripionsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_Artist_Id",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_playlists_Users_User_Id",
                table: "playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_Song_Id",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_playlists_Playlist_Id",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_Album_Id",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_Artist_Id",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_Subscription_ID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Subscription_ID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Songs_Album_Id",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_Artist_Id",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_Song_Id",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlists_User_Id",
                table: "playlists");

            migrationBuilder.DropIndex(
                name: "IX_Albums_Artist_Id",
                table: "Albums");

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongsID",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongsID",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongsID",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Albums_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PlaylistSongsID",
                table: "PlaylistSongs");

            migrationBuilder.RenameTable(
                name: "PlaylistSongs",
                newName: "playlistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistSongs_Playlist_Id",
                table: "playlistSongs",
                newName: "IX_playlistSongs_Playlist_Id");

            migrationBuilder.RenameColumn(
                name: "Albums_Id",
                table: "Albums",
                newName: "AlbumsId");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                columns: new[] { "Song_Id", "Playlist_Id" });

            migrationBuilder.CreateTable(
                name: "Subscripions",
                columns: table => new
                {
                    SubscripionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subscripions_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscripions", x => x.SubscripionsId);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongsId", "Album_Id", "Artist_Id", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 5, 2, 3, "4:15m", "Pop", "Sunset" },
                    { 6, 2, 4, "3:45m", "Rock", "Midnight Drive" },
                    { 7, 3, 5, "5:00m", "Ballad", "Eternal Flame" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Join_Date" },
                values: new object[] { "hanan1@gmail.com", "1-1-1999" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Join_Date", "Subscription_ID" },
                values: new object[] { "reem2@gmail.com", "4-4-2004", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { 3, "haya3@gmail.com", "1-8-2008", 3, "haya" });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlaylistsId", "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[,]
                {
                    { 3, "15-8-2024", "Summer Vibes", 2 },
                    { 4, "30-8-2024", "Chill Beats", 2 },
                    { 5, "12-9-2024", "Workout Tunes", 3 }
                });

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
    }
}
