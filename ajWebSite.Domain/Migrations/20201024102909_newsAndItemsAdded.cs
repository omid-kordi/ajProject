using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class newsAndItemsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fileBinaryType",
                table: "FileBinary",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "FileBinary",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    parentId = table.Column<int>(nullable: false),
                    groupType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Group_parentId",
                        column: x => x.parentId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "newsAndItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    releaseType = table.Column<int>(nullable: false),
                    beginReleaseDateTime = table.Column<DateTime>(nullable: true),
                    endReleaseDatetime = table.Column<DateTime>(nullable: true),
                    tags = table.Column<string>(nullable: true),
                    groupId = table.Column<int>(nullable: true),
                    price = table.Column<float>(nullable: false),
                    businessType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsAndItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newsAndItem_Group_groupId",
                        column: x => x.groupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_parentId",
                table: "Group",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_newsAndItem_groupId",
                table: "newsAndItem",
                column: "groupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newsAndItem");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropColumn(
                name: "fileBinaryType",
                table: "FileBinary");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "FileBinary");
        }
    }
}
