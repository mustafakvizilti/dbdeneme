using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dbdeneme.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartmanlar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departmanlar",
                columns: new[] { "Id", "Aciklama", "Ad", "AktifMi" },
                values: new object[,]
                {
                    { 1, "Yazılım ve sistem altyapıları yönetimi", "Bilgi Teknolojileri", true },
                    { 2, "Personel yönetimi ve işe alım süreçleri", "İnsan Kaynakları", true },
                    { 3, "Finansal işlemler ve raporlar", "Muhasebe", true },
                    { 4, "Satış operasyonları ve müşteri ilişkileri", "Satış", true },
                    { 5, "Pazar araştırmaları ve reklam çalışmaları", "Pazarlama", true },
                    { 6, "Yeni ürün ve hizmetlerin geliştirilmesi", "Ar-Ge", true },
                    { 7, "Ürünlerin üretim süreci ve kalite kontrolü", "Üretim", true },
                    { 8, "İdari ve teknik destek sağlama", "Destek Hizmetleri", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departmanlar",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
