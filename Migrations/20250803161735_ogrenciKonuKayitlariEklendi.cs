using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class ogrenciKonuKayitlariEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciKonuAtamalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    EgitimYiliId = table.Column<int>(type: "INTEGER", nullable: false),
                    KonuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciKonuAtamalari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciKonuAtamalari_EgitimYillari_EgitimYiliId",
                        column: x => x.EgitimYiliId,
                        principalTable: "EgitimYillari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciKonuAtamalari_Konular_KonuId",
                        column: x => x.KonuId,
                        principalTable: "Konular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciKonuAtamalari_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciKonuAtamalari_EgitimYiliId",
                table: "OgrenciKonuAtamalari",
                column: "EgitimYiliId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciKonuAtamalari_KonuId",
                table: "OgrenciKonuAtamalari",
                column: "KonuId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciKonuAtamalari_StudentId",
                table: "OgrenciKonuAtamalari",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciKonuAtamalari");
        }
    }
}
