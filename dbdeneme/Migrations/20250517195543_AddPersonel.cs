using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "PersonelIzinler",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIzinler_IzinId",
                table: "PersonelIzinler",
                column: "IzinId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelIzinler_Izinler_IzinId",
                table: "PersonelIzinler",
                column: "IzinId",
                principalTable: "Izinler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelIzinler_Izinler_IzinId",
                table: "PersonelIzinler");

            migrationBuilder.DropIndex(
                name: "IX_PersonelIzinler_IzinId",
                table: "PersonelIzinler");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "PersonelIzinler");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Izinler");
        }
    }
}
