using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class kesin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Pozisyonlar_PozisyonId",
                table: "Personeller");

            migrationBuilder.AlterColumn<int>(
                name: "PozisyonId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller",
                column: "DepartmanId",
                principalTable: "Departmanlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Pozisyonlar_PozisyonId",
                table: "Personeller",
                column: "PozisyonId",
                principalTable: "Pozisyonlar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Pozisyonlar_PozisyonId",
                table: "Personeller");

            migrationBuilder.AlterColumn<int>(
                name: "PozisyonId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller",
                column: "DepartmanId",
                principalTable: "Departmanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Pozisyonlar_PozisyonId",
                table: "Personeller",
                column: "PozisyonId",
                principalTable: "Pozisyonlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
