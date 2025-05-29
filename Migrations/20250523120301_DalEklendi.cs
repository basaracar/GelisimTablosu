using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class DalEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dal",
                table: "Konular",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dal",
                table: "Konular");
        }
    }
}
