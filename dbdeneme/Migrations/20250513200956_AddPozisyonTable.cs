using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class AddPozisyonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PozisyonId",
                table: "Pozisyonlar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmanId",
                table: "Departmanlar",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Pozisyonlar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Pozisyonlar",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Pozisyonlar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Departmanlar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Departmanlar",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Departmanlar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Pozisyonlar");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Departmanlar");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Departmanlar");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pozisyonlar",
                newName: "PozisyonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departmanlar",
                newName: "DepartmanId");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Departmanlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
