using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDBroodjes.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persoon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoorNaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchterNaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geslacht = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotaalPrijs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Broodje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prijs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestellingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broodje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersoonID = table.Column<int>(type: "int", nullable: false),
                    BroodjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestelling_Broodje_BroodjeID",
                        column: x => x.BroodjeID,
                        principalTable: "Broodje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bestelling_Persoon_PersoonID",
                        column: x => x.PersoonID,
                        principalTable: "Persoon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_BroodjeID",
                table: "Bestelling",
                column: "BroodjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_PersoonID",
                table: "Bestelling",
                column: "PersoonID");

            migrationBuilder.CreateIndex(
                name: "IX_Broodje_BestellingId",
                table: "Broodje",
                column: "BestellingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Broodje_Bestelling_BestellingId",
                table: "Broodje",
                column: "BestellingId",
                principalTable: "Bestelling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Broodje_BroodjeID",
                table: "Bestelling");

            migrationBuilder.DropTable(
                name: "Broodje");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "Persoon");
        }
    }
}
