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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AdSoyad = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Binalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    KatSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    InşaatTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Daireler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DaireNo = table.Column<string>(type: "TEXT", nullable: false),
                    DaireTipi = table.Column<string>(type: "TEXT", nullable: false),
                    Kat = table.Column<int>(type: "INTEGER", nullable: false),
                    PetekSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BinaId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Gecmisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Islem = table.Column<string>(type: "TEXT", nullable: false),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "TEXT", nullable: false),
                    DaireId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HesapAdi = table.Column<string>(type: "TEXT", nullable: false),
                    HesapTipi = table.Column<string>(type: "TEXT", nullable: false),
                    Bakiye = table.Column<decimal>(type: "TEXT", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DaireId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AktifMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    DaireId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AktifMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    DaireId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Icerik = table.Column<string>(type: "TEXT", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OlusturanKullanici = table.Column<string>(type: "TEXT", nullable: false),
                    Hatirlatma = table.Column<bool>(type: "INTEGER", nullable: false),
                    HatirlatmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DaireId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tipi = table.Column<string>(type: "TEXT", nullable: false),
                    Tutar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    HesapId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daireler_BinaId",
                table: "Daireler",
                column: "BinaId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hesaplar");

            migrationBuilder.DropTable(
                name: "Daireler");

            migrationBuilder.DropTable(
                name: "Binalar");
        }
    }
}
