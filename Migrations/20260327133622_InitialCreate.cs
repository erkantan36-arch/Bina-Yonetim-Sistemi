using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaDaireYonetim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Binalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatSayisi = table.Column<int>(type: "int", nullable: false),
                    InşaatTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Daireler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kat = table.Column<int>(type: "int", nullable: false),
                    MetreKare = table.Column<double>(type: "float", nullable: false),
                    Sahibi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daireler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Daireler_Binalar_BinaId",
                        column: x => x.BinaId,
                        principalTable: "Binalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Daireler_BinaId",
                table: "Daireler",
                column: "BinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daireler");

            migrationBuilder.DropTable(
                name: "Binalar");
        }
    }
}
