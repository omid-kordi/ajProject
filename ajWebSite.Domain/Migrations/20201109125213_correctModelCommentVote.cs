using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class correctModelCommentVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isValid",
                table: "vote",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isValid",
                table: "comment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isValid",
                table: "vote");

            migrationBuilder.DropColumn(
                name: "isValid",
                table: "comment");
        }
    }
}
