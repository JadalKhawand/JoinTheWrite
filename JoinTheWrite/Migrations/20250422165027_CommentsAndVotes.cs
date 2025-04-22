using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinTheWrite.Migrations
{
    /// <inheritdoc />
    public partial class CommentsAndVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Creations_CreationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Creations_CreationId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_CreationId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "CreationId",
                table: "Contributions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Votes",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                newName: "IX_Votes_AuthorId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "ChapterId");

            migrationBuilder.RenameColumn(
                name: "ParentCommentId",
                table: "Comments",
                newName: "ContributionId");

            migrationBuilder.RenameColumn(
                name: "CreationId",
                table: "Comments",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                newName: "IX_Comments_ContributionId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreationId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Chapters",
                newName: "FinalizedTitle");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contributions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UpvoteCount",
                table: "Contributions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Chapters_ChapterId",
                table: "Comments",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Contributions_ContributionId",
                table: "Comments",
                column: "ContributionId",
                principalTable: "Contributions",
                principalColumn: "ContributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_AuthorId",
                table: "Votes",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Chapters_ChapterId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Contributions_ContributionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_AuthorId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "UpvoteCount",
                table: "Contributions");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Votes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_AuthorId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameColumn(
                name: "ContributionId",
                table: "Comments",
                newName: "ParentCommentId");

            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Comments",
                newName: "CreationId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ContributionId",
                table: "Comments",
                newName: "IX_Comments_ParentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ChapterId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                newName: "IX_Comments_CreationId");

            migrationBuilder.RenameColumn(
                name: "FinalizedTitle",
                table: "Chapters",
                newName: "Title");

            migrationBuilder.AddColumn<Guid>(
                name: "CreationId",
                table: "Contributions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_CreationId",
                table: "Contributions",
                column: "CreationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Creations_CreationId",
                table: "Comments",
                column: "CreationId",
                principalTable: "Creations",
                principalColumn: "CreationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Creations_CreationId",
                table: "Contributions",
                column: "CreationId",
                principalTable: "Creations",
                principalColumn: "CreationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
