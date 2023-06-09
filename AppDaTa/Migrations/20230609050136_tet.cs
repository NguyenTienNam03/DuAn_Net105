using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDaTa.Migrations
{
    public partial class tet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    IDRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.IDRole);
                });

            migrationBuilder.CreateTable(
                name: "HangSX",
                columns: table => new
                {
                    IDHangSx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHangSX = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSX", x => x.IDHangSx);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    IDMau = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mausac = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.IDMau);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IDSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSale = table.Column<string>(type: "varchar(10)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "DateTime", nullable: false),
                    GiaTriSale = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IDSale);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    IdSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.IdSP);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    IDSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeGiay = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.IDSize);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    IDTheLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenTheLoai = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoai", x => x.IDTheLoai);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaVoucher = table.Column<string>(type: "varchar(10)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Dieukien = table.Column<decimal>(type: "decimal", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "DateTime", nullable: false),
                    GiaTriVoucher = table.Column<decimal>(type: "decimal", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.IDVoucher);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SDT = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(20)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_NguoiDung_ChucVu_IDRole",
                        column: x => x.IDRole,
                        principalTable: "ChucVu",
                        principalColumn: "IDRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamChiTiet",
                columns: table => new
                {
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDMau = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSale = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDTheLoai = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal", nullable: false),
                    GiaSale = table.Column<decimal>(type: "decimal", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Anh = table.Column<string>(type: "varchar(1000)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiet", x => x.IDSPCT);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_HangSX_IDHang",
                        column: x => x.IDHang,
                        principalTable: "HangSX",
                        principalColumn: "IDHangSx",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_MauSac_IDMau",
                        column: x => x.IDMau,
                        principalTable: "MauSac",
                        principalColumn: "IDMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_Sale_IDSale",
                        column: x => x.IDSale,
                        principalTable: "Sale",
                        principalColumn: "IDSale");
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_SanPham_IDSP",
                        column: x => x.IDSP,
                        principalTable: "SanPham",
                        principalColumn: "IdSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_Size_IDSize",
                        column: x => x.IDSize,
                        principalTable: "Size",
                        principalColumn: "IDSize",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_TheLoai_IDTheLoai",
                        column: x => x.IDTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "IDTheLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    IDGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.IDGioHang);
                    table.ForeignKey(
                        name: "FK_GioHang_NguoiDung_IDGioHang",
                        column: x => x.IDGioHang,
                        principalTable: "NguoiDung",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHD = table.Column<string>(type: "varchar(15)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NgayShip = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SDTNguoiNhan = table.Column<string>(type: "varchar(10)", nullable: false),
                    DiaChiNguoiNhan = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.IdBill);
                    table.ForeignKey(
                        name: "FK_HoaDon_NguoiDung_IDKhachHang",
                        column: x => x.IDKhachHang,
                        principalTable: "NguoiDung",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_Voucher_IDVoucher",
                        column: x => x.IDVoucher,
                        principalTable: "Voucher",
                        principalColumn: "IDVoucher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    IDBinhLuan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    NgayBinh = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.IDBinhLuan);
                    table.ForeignKey(
                        name: "FK_BinhLuan_NguoiDung_IDNguoiDung",
                        column: x => x.IDNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinhLuan_SanPhamChiTiet_IDSPCT",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IDSPCT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiet",
                columns: table => new
                {
                    IDGHCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDGH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiet", x => x.IDGHCT);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_GioHang_IDGH",
                        column: x => x.IDGH,
                        principalTable: "GioHang",
                        principalColumn: "IDGioHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_SanPhamChiTiet_IDSPCT",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IDSPCT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCT",
                columns: table => new
                {
                    IDHDCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCT", x => x.IDHDCT);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_HoaDon_IDHD",
                        column: x => x.IDHD,
                        principalTable: "HoaDon",
                        principalColumn: "IdBill",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_SanPhamChiTiet_IDSPCT",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IDSPCT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_IDNguoiDung",
                table: "BinhLuan",
                column: "IDNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_IDSPCT",
                table: "BinhLuan",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiet_IDGH",
                table: "GioHangChiTiet",
                column: "IDGH");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiet_IDSPCT",
                table: "GioHangChiTiet",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDKhachHang",
                table: "HoaDon",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDVoucher",
                table: "HoaDon",
                column: "IDVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_IDHD",
                table: "HoaDonCT",
                column: "IDHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_IDSPCT",
                table: "HoaDonCT",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_IDRole",
                table: "NguoiDung",
                column: "IDRole");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDHang",
                table: "SanPhamChiTiet",
                column: "IDHang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDMau",
                table: "SanPhamChiTiet",
                column: "IDMau");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDSale",
                table: "SanPhamChiTiet",
                column: "IDSale");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDSize",
                table: "SanPhamChiTiet",
                column: "IDSize");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDSP",
                table: "SanPhamChiTiet",
                column: "IDSP");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDTheLoai",
                table: "SanPhamChiTiet",
                column: "IDTheLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan");

            migrationBuilder.DropTable(
                name: "GioHangChiTiet");

            migrationBuilder.DropTable(
                name: "HoaDonCT");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPhamChiTiet");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "HangSX");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "TheLoai");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
