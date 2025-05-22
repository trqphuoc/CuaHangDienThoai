using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuaHangDienThoai.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    Id_DanhMuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_DanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Id_DanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id_NguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Dang_Nhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mat_Khau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ho_Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    So_Dien_Thoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Dia_Chi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngay_Tao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id_NguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id_SanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_SanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mo_Ta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DungLuongLuuTru = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KichThuocManHinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BaoHanh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoKheCamSim = table.Column<int>(type: "int", nullable: false),
                    So_Luong = table.Column<int>(type: "int", nullable: false),
                    Id_DanhMuc = table.Column<int>(type: "int", nullable: true),
                    Anh_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id_SanPham);
                    table.ForeignKey(
                        name: "FK_SanPhams_DanhMucs_Id_DanhMuc",
                        column: x => x.Id_DanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "Id_DanhMuc",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    Id_DonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Tong_Tien = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ngay_Tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dia_Chi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.Id_DonHang);
                    table.ForeignKey(
                        name: "FK_DonHangs_NguoiDungs_Id_NguoiDung",
                        column: x => x.Id_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHangs",
                columns: table => new
                {
                    Id_ChiTietDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_DonHang = table.Column<int>(type: "int", nullable: false),
                    Id_SanPham = table.Column<int>(type: "int", nullable: false),
                    So_Luong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangs", x => x.Id_ChiTietDonHang);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_DonHangs_Id_DonHang",
                        column: x => x.Id_DonHang,
                        principalTable: "DonHangs",
                        principalColumn: "Id_DonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_SanPhams_Id_SanPham",
                        column: x => x.Id_SanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id_SanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGias",
                columns: table => new
                {
                    Id_DanhGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Id_SanPham = table.Column<int>(type: "int", nullable: false),
                    Id_DonHang = table.Column<int>(type: "int", nullable: false),
                    So_Sao = table.Column<int>(type: "int", nullable: false),
                    Nhan_Xet = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ngay_DanhGia = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGias", x => x.Id_DanhGia);
                    table.CheckConstraint("CK_DanhGia_SoSao", "[So_Sao] BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_DanhGias_DonHangs_Id_DonHang",
                        column: x => x.Id_DonHang,
                        principalTable: "DonHangs",
                        principalColumn: "Id_DonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGias_NguoiDungs_Id_NguoiDung",
                        column: x => x.Id_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id_NguoiDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhGias_SanPhams_Id_SanPham",
                        column: x => x.Id_SanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id_SanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_Id_DonHang",
                table: "ChiTietDonHangs",
                column: "Id_DonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_Id_SanPham",
                table: "ChiTietDonHangs",
                column: "Id_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_Id_DonHang",
                table: "DanhGias",
                column: "Id_DonHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_Id_NguoiDung",
                table: "DanhGias",
                column: "Id_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_Id_SanPham",
                table: "DanhGias",
                column: "Id_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_Id_NguoiDung",
                table: "DonHangs",
                column: "Id_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Id_DanhMuc",
                table: "SanPhams",
                column: "Id_DanhMuc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "DanhGias");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "DanhMucs");
        }
    }
}
