    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAndTelefonToPersonel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Personeller");
        }
    }
}
