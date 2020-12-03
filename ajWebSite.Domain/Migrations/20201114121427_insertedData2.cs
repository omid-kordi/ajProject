using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class insertedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "salon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    saloonName = table.Column<string>(nullable: true),
                    addressState = table.Column<string>(nullable: true),
                    addressCity = table.Column<string>(nullable: true),
                    addressDetails = table.Column<string>(nullable: true),
                    pstalCode = table.Column<string>(nullable: true),
                    salonPhone = table.Column<string>(nullable: true),
                    seriveses = table.Column<string>(nullable: true),
                    packages = table.Column<string>(nullable: true),
                    locationLat = table.Column<string>(nullable: true),
                    locationLan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salon", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "salon");
        }
    }
}
