using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkSharingRepository.Migrations
{
    /// <inheritdoc />
    public partial class addpublicurlcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicURl",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicURl",
                table: "Users");
        }
    }
}
