using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class questionTitleProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "questionTitle",
                table: "surveyQuestion",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "questionTitle",
                table: "surveyQuestion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
