using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkSharingRepository.Migrations
{
    /// <inheritdoc />
    public partial class addeddisplayindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayIndex",
                table: "CustomLinks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayIndex",
                table: "CustomLinks");
        }
    }
}
