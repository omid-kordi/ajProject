using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class ticketSystemCorrectness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecieverId",
                table: "ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_RecieverId",
                table: "ticket",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_SenderId",
                table: "ticket",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_Users_RecieverId",
                table: "ticket",
                column: "RecieverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_Users_SenderId",
                table: "ticket",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_Users_RecieverId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_Users_SenderId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_RecieverId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_SenderId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "ticket");
        }
    }
}
