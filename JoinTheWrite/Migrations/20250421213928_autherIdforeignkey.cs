using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class autherIdforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creations_Users_UserAuthorId",
                table: "Creations");

            migrationBuilder.DropIndex(
                name: "IX_Creations_UserAuthorId",
                table: "Creations");

            migrationBuilder.DropColumn(
                name: "UserAuthorId",
                table: "Creations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAuthorId",
                table: "Creations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creations_UserAuthorId",
                table: "Creations",
                column: "UserAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Creations_Users_UserAuthorId",
                table: "Creations",
                column: "UserAuthorId",
                principalTable: "Users",
                principalColumn: "AuthorId");
        }
    }
}
