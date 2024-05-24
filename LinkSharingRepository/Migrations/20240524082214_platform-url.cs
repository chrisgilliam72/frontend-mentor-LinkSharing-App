using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkSharingRepository.Migrations
{
    /// <inheritdoc />
    public partial class platformurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Platforms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1,
                column: "URL",
                value: "www.stackoverflow.com");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                column: "URL",
                value: "www.youtube.com");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3,
                column: "URL",
                value: "www.github.com");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "www.facebook.com");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5,
                column: "URL",
                value: "www.twitter.com");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7,
                column: "URL",
                value: "www.twitch.tv");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8,
                column: "URL",
                value: "www.linkedin.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Platforms");
        }
    }
}
