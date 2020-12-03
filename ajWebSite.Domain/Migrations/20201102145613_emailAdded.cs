﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class emailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "emailAddress",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailAddress",
                table: "Users");
        }
    }
}
