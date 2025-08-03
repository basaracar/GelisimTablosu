using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class IsletmeEklendi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isletme",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isletme",
                table: "Students");
        }
    }
}
