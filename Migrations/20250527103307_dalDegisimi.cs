using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class dalDegisimi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dal",
                table: "Kategoriler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dal",
                table: "Kategoriler");
        }
    }
}
