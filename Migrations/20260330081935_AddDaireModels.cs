using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaDaireYonetim.Migrations
{
    /// <inheritdoc />
    public partial class AddDaireModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetreKare",
                table: "Daireler");

            migrationBuilder.RenameColumn(
                name: "Sahibi",
                table: "Daireler",
                newName: "DaireTipi");

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Daireler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetekSayisi",
                table: "Daireler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gecmisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Islem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gecmisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gecmisler_Daireler_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daireler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hesaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bakiye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hesaplar_Daireler_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daireler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KatMalikleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatMalikleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KatMalikleri_Daireler_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daireler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kiracıları",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiracıları", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kiracıları_Daireler_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daireler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hatirlatma = table.Column<bool>(type: "bit", nullable: false),
                    HatirlatmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notlar_Daireler_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daireler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HesapIslemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapIslemler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HesapIslemler_Hesaplar_HesapId",
                        column: x => x.HesapId,
                        principalTable: "Hesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gecmisler_DaireId",
                table: "Gecmisler",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_HesapIslemler_HesapId",
                table: "HesapIslemler",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_DaireId",
                table: "Hesaplar",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_KatMalikleri_DaireId",
                table: "KatMalikleri",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Kiracıları_DaireId",
                table: "Kiracıları",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Notlar_DaireId",
                table: "Notlar",
                column: "DaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gecmisler");

            migrationBuilder.DropTable(
                name: "HesapIslemler");

            migrationBuilder.DropTable(
                name: "KatMalikleri");

            migrationBuilder.DropTable(
                name: "Kiracıları");

            migrationBuilder.DropTable(
                name: "Notlar");

            migrationBuilder.DropTable(
                name: "Hesaplar");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Daireler");

            migrationBuilder.DropColumn(
                name: "PetekSayisi",
                table: "Daireler");

            migrationBuilder.RenameColumn(
                name: "DaireTipi",
                table: "Daireler",
                newName: "Sahibi");

            migrationBuilder.AddColumn<double>(
                name: "MetreKare",
                table: "Daireler",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
