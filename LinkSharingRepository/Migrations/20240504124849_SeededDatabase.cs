using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LinkSharingRepository.Migrations
{
    /// <inheritdoc />
    public partial class SeededDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconLocation",
                table: "Platforms",
                newName: "Icon");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "icon-stack-overflow.svg", "Stack Overflow" },
                    { 2, "icon-youtube.svg", "You Tube" },
                    { 3, "icon-gitlab.svg", "GitHub" },
                    { 4, "icon-facebook.svg", "Facebook" },
                    { 5, "icon-twitter.svg", "Twitter" },
                    { 6, "icon-freecodecamp.svg", "Free Code Camp" },
                    { 7, "icon-twitch.svg", "Twitch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Platforms",
                newName: "IconLocation");
        }
    }
}
