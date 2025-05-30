using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class TakvimEgitimYiliEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EgitimYillari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaslangicTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitimYillari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Takvimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hafta = table.Column<string>(type: "TEXT", nullable: false),
                    Zorluk = table.Column<int>(type: "INTEGER", nullable: false),
                    EgitimYiliId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takvimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Takvimler_EgitimYillari_EgitimYiliId",
                        column: x => x.EgitimYiliId,
                        principalTable: "EgitimYillari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Takvimler_EgitimYiliId",
                table: "Takvimler",
                column: "EgitimYiliId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Takvimler");

            migrationBuilder.DropTable(
                name: "EgitimYillari");
        }
    }
}
