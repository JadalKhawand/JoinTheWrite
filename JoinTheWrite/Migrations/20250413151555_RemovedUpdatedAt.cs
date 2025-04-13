using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUpdatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Creations_CreationId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_CreationId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Chapters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Chapters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CreationId",
                table: "Chapters",
                column: "CreationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Creations_CreationId",
                table: "Chapters",
                column: "CreationId",
                principalTable: "Creations",
                principalColumn: "CreationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
