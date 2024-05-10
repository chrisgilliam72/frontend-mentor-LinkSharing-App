using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkSharingRepository.Migrations
{
    /// <inheritdoc />
    public partial class userphotoandformat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoFormat",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrandingColor",
                value: "#FF0000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoFormat",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrandingColor",
                value: "#212121");
        }
    }
}
