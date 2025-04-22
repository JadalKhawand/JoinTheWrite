using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Creations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Creations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
