using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class initSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "surveyQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    questionTitle = table.Column<int>(nullable: false),
                    questionOptions = table.Column<string>(nullable: true),
                    isRequired = table.Column<bool>(nullable: false),
                    surveyQuestionType = table.Column<int>(nullable: false),
                    questionDescription = table.Column<string>(nullable: true),
                    surveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_surveyQuestion_survey_surveyId",
                        column: x => x.surveyId,
                        principalTable: "survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "surveyQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    questionAnswer = table.Column<string>(nullable: true),
                    questionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_surveyQuestionAnswer_surveyQuestion_questionId",
                        column: x => x.questionId,
                        principalTable: "surveyQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_surveyQuestion_surveyId",
                table: "surveyQuestion",
                column: "surveyId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyQuestionAnswer_questionId",
                table: "surveyQuestionAnswer",
                column: "questionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "surveyQuestionAnswer");

            migrationBuilder.DropTable(
                name: "surveyQuestion");

            migrationBuilder.DropTable(
                name: "survey");
        }
    }
}
