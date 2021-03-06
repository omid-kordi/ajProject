﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class siteConfigsAddedd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "configName",
                table: "config",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "configName",
                table: "config",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
