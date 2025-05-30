using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class EgitimYiliDuzektme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zorluk",
                table: "Takvimler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Zorluk",
                table: "Takvimler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
