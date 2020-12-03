using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class correctingAttachmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "attachmentType",
                table: "FileBinary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ownerID",
                table: "FileBinary",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attachmentType",
                table: "FileBinary");

            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "FileBinary");
        }
    }
}
