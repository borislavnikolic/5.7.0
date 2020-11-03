using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace orion.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 255, nullable: false),
                    Duration = table.Column<byte>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Gratis = table.Column<byte>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 65536, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ConcractID = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Concract_ConcractID",
                        column: x => x.ConcractID,
                        principalTable: "Concract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageXConcract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcractID = table.Column<int>(nullable: false),
                    PackageID = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageXConcract", x => x.Id);
                    table.UniqueConstraint("IX_MultipleColumns", x => new { x.PackageID, x.ConcractID });
                    table.ForeignKey(
                        name: "FK_PackageXConcract_Concract_ConcractID",
                        column: x => x.ConcractID,
                        principalTable: "Concract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageXConcract_Package_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_ConcractID",
                table: "History",
                column: "ConcractID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageXConcract_ConcractID",
                table: "PackageXConcract",
                column: "ConcractID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "PackageXConcract");

            migrationBuilder.DropTable(
                name: "Concract");

            migrationBuilder.DropTable(
                name: "Package");
        }
    }
}
