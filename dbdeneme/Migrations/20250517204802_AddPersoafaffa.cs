using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class AddPersoafaffa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelIzinler");

            migrationBuilder.DropTable(
                name: "Izinler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Izinler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelIzinler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelIzinler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelIzinler_Izinler_IzinId",
                        column: x => x.IzinId,
                        principalTable: "Izinler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelIzinler_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIzinler_IzinId",
                table: "PersonelIzinler",
                column: "IzinId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIzinler_PersonelId",
                table: "PersonelIzinler",
                column: "PersonelId");
        }
    }
}
