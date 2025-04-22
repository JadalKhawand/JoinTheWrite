using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class addedForeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAuthorId",
                table: "Creations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creations_AuthorId",
                table: "Creations",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Creations_UserAuthorId",
                table: "Creations",
                column: "UserAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CreationId",
                table: "Chapters",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_FinalizedContributionId",
                table: "Chapters",
                column: "FinalizedContributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Contributions_FinalizedContributionId",
                table: "Chapters",
                column: "FinalizedContributionId",
                principalTable: "Contributions",
                principalColumn: "ContributionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Creations_CreationId",
                table: "Chapters",
                column: "CreationId",
                principalTable: "Creations",
                principalColumn: "CreationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Creations_Users_AuthorId",
                table: "Creations",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Creations_Users_UserAuthorId",
                table: "Creations",
                column: "UserAuthorId",
                principalTable: "Users",
                principalColumn: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Contributions_FinalizedContributionId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Creations_CreationId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Creations_Users_AuthorId",
                table: "Creations");

            migrationBuilder.DropForeignKey(
                name: "FK_Creations_Users_UserAuthorId",
                table: "Creations");

            migrationBuilder.DropIndex(
                name: "IX_Creations_AuthorId",
                table: "Creations");

            migrationBuilder.DropIndex(
                name: "IX_Creations_UserAuthorId",
                table: "Creations");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_CreationId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_FinalizedContributionId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "UserAuthorId",
                table: "Creations");
        }
    }
}
