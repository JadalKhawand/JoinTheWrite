using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class addedAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Users",
                newName: "UserId");
        }
    }
}
