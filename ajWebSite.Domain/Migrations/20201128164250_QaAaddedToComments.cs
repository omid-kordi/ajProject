using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class QaAaddedToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "commentType",
                table: "comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parentId",
                table: "comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comment_parentId",
                table: "comment",
                column: "parentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_comment_parentId",
                table: "comment",
                column: "parentId",
                principalTable: "comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_comment_parentId",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_parentId",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "commentType",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "parentId",
                table: "comment");
        }
    }
}
