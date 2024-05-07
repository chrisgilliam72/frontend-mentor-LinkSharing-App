using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkSharingRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlatformEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "BrandingColor",
                table: "Platforms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrandingColor",
                value: "#f48024");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrandingColor",
                value: "#212121");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3,
                column: "BrandingColor",
                value: "#333");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4,
                column: "BrandingColor",
                value: "#4267B2");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5,
                column: "BrandingColor",
                value: "#1DA1F2");

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7,
                column: "BrandingColor",
                value: "#9146ff");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "BrandingColor", "Icon", "Name" },
                values: new object[] { 8, "#0a66c2", "icon-LinkedIn.svg", "LinkedIn" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "BrandingColor",
                table: "Platforms");

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 6, "icon-freecodecamp.svg", "Free Code Camp" });
        }
    }
}
