using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class addedTitleToChapter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Chapters");
        }
    }
}
