using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ajWebSite.Domain.Migrations
{
    public partial class park : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivationCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 5, nullable: true),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileBinary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    GUId = table.Column<string>(type: "varchar(36)", maxLength: 40, nullable: true),
                    Binary = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileBinary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    DigitalReceipt = table.Column<string>(maxLength: 100, nullable: true),
                    CardNumber = table.Column<string>(maxLength: 20, nullable: true),
                    TerminalNumber = table.Column<string>(maxLength: 20, nullable: true),
                    RefNumber = table.Column<string>(maxLength: 20, nullable: true),
                    TrackingCode = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    PersonType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true),
                    Result = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parking_Lookup_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Job = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    RegisterNumber = table.Column<string>(maxLength: 10, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    CompanyTypeId = table.Column<int>(nullable: true),
                    EcoNumber = table.Column<string>(maxLength: 11, nullable: true),
                    RepNationalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 10, nullable: true),
                    Province = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    BankBranch = table.Column<string>(maxLength: 30, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 30, nullable: true),
                    AccountSheba = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Lookup_BankId",
                        column: x => x.BankId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Lookup_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonDoc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: false),
                    FileBinaryUId = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDoc_Lookup_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDoc_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    NumberOfLoginAttempt = table.Column<int>(nullable: false),
                    LastLoginAttemptDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsFullRegistered = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Lookup_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: true),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AccessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccess_Access_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Access",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccess_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileBinary_GUId",
                table: "FileBinary",
                column: "GUId");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_TypeId",
                table: "Parking",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_BankId",
                table: "PersonDetail",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_CompanyTypeId",
                table: "PersonDetail",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDoc_FileTypeId",
                table: "PersonDoc",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDoc_PersonId",
                table: "PersonDoc",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_AccessId",
                table: "UserAccess",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_UserId",
                table: "UserAccess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationCode");

            migrationBuilder.DropTable(
                name: "FileBinary");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PersonDetail");

            migrationBuilder.DropTable(
                name: "PersonDoc");

            migrationBuilder.DropTable(
                name: "TextMessage");

            migrationBuilder.DropTable(
                name: "UserAccess");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
