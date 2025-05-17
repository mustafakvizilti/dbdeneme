using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaslangicTarihi",
                table: "Maaslar",
                newName: "OdemeTarihi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OdemeTarihi",
                table: "Maaslar",
                newName: "BaslangicTarihi");
        }
    }
}
