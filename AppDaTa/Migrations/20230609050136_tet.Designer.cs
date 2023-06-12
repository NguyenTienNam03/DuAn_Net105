﻿// <auto-generated />
using System;
using AppDaTa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDaTa.Migrations
{
    [DbContext(typeof(QLBG_Context))]
    [Migration("20230609050136_tet")]
    partial class tet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppDaTa.Models.BinhLuan", b =>
                {
                    b.Property<Guid>("IDBinhLuan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSPCT")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayBinh")
                        .HasColumnType("DateTime");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("IDBinhLuan");

                    b.HasIndex("IDNguoiDung");

                    b.HasIndex("IDSPCT");

                    b.ToTable("BinhLuan", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.ChucVu", b =>
                {
                    b.Property<Guid>("IDRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDRole");

                    b.ToTable("ChucVu", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.GioHang", b =>
                {
                    b.Property<Guid>("IDGioHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDGioHang");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("IDGHCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal");

                    b.Property<Guid>("IDGH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSPCT")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IDGHCT");

                    b.HasIndex("IDGH");

                    b.HasIndex("IDSPCT");

                    b.ToTable("GioHangChiTiet", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.HangSX", b =>
                {
                    b.Property<Guid>("IDHangSx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenHangSX")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("IDHangSx");

                    b.ToTable("HangSX", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.HoaDon", b =>
                {
                    b.Property<Guid>("IdBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChiNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal");

                    b.Property<Guid>("IDKhachHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDVoucher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaHD")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("NgayShip")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("DateTime");

                    b.Property<string>("SDTNguoiNhan")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdBill");

                    b.HasIndex("IDKhachHang");

                    b.HasIndex("IDVoucher");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("IDHDCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal");

                    b.Property<Guid>("IDHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSPCT")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IDHDCT");

                    b.HasIndex("IDHD");

                    b.HasIndex("IDSPCT");

                    b.ToTable("HoaDonCT", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.MauSac", b =>
                {
                    b.Property<Guid>("IDMau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mausac")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IDMau");

                    b.ToTable("MauSac", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.NguoiDung", b =>
                {
                    b.Property<Guid>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("IDRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDUser");

                    b.HasIndex("IDRole");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.Sale", b =>
                {
                    b.Property<Guid>("IDSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GiaTriSale")
                        .HasColumnType("int");

                    b.Property<string>("MaSale")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("DateTime");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDSale");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.SanPham", b =>
                {
                    b.Property<Guid>("IdSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSP");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.SanPhamChiTiet", b =>
                {
                    b.Property<Guid>("IDSPCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anh")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal");

                    b.Property<decimal>("GiaSale")
                        .HasColumnType("decimal");

                    b.Property<Guid>("IDHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDMau")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDSale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSize")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDTheLoai")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDSPCT");

                    b.HasIndex("IDHang");

                    b.HasIndex("IDMau");

                    b.HasIndex("IDSP");

                    b.HasIndex("IDSale");

                    b.HasIndex("IDSize");

                    b.HasIndex("IDTheLoai");

                    b.ToTable("SanPhamChiTiet", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.Size", b =>
                {
                    b.Property<Guid>("IDSize")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SizeGiay")
                        .HasColumnType("decimal");

                    b.HasKey("IDSize");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.TheLoai", b =>
                {
                    b.Property<Guid>("IDTheLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("TenTheLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDTheLoai");

                    b.ToTable("TheLoai", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.Voucher", b =>
                {
                    b.Property<Guid>("IDVoucher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Dieukien")
                        .HasColumnType("decimal");

                    b.Property<decimal>("GiaTriVoucher")
                        .HasColumnType("decimal");

                    b.Property<string>("MaVoucher")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("DateTime");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDVoucher");

                    b.ToTable("Voucher", (string)null);
                });

            modelBuilder.Entity("AppDaTa.Models.BinhLuan", b =>
                {
                    b.HasOne("AppDaTa.Models.NguoiDung", "NguoiDung")
                        .WithMany("BinhLuans")
                        .HasForeignKey("IDNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.SanPhamChiTiet", "SanPhamCT")
                        .WithMany("BinhLuans")
                        .HasForeignKey("IDSPCT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPhamCT");
                });

            modelBuilder.Entity("AppDaTa.Models.GioHang", b =>
                {
                    b.HasOne("AppDaTa.Models.NguoiDung", "NguoiDung")
                        .WithMany("GioHangs")
                        .HasForeignKey("IDGioHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("AppDaTa.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("AppDaTa.Models.GioHang", "GioHang")
                        .WithMany("GioHangcts")
                        .HasForeignKey("IDGH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.SanPhamChiTiet", "SanPhamCT")
                        .WithMany("GioHangCT")
                        .HasForeignKey("IDSPCT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioHang");

                    b.Navigation("SanPhamCT");
                });

            modelBuilder.Entity("AppDaTa.Models.HoaDon", b =>
                {
                    b.HasOne("AppDaTa.Models.NguoiDung", "NguoiDung")
                        .WithMany("HoaDons")
                        .HasForeignKey("IDKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.Voucher", "Voucher")
                        .WithMany("HoaDons")
                        .HasForeignKey("IDVoucher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("AppDaTa.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("AppDaTa.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonCTs")
                        .HasForeignKey("IDHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.SanPhamChiTiet", "SanPhamct")
                        .WithMany("HoaDonCT")
                        .HasForeignKey("IDSPCT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("SanPhamct");
                });

            modelBuilder.Entity("AppDaTa.Models.NguoiDung", b =>
                {
                    b.HasOne("AppDaTa.Models.ChucVu", "ChucVu")
                        .WithMany("NguoiDung")
                        .HasForeignKey("IDRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("AppDaTa.Models.SanPhamChiTiet", b =>
                {
                    b.HasOne("AppDaTa.Models.HangSX", "Hang")
                        .WithMany("SanPhamCT")
                        .HasForeignKey("IDHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.MauSac", "Mau")
                        .WithMany("SanPhamct")
                        .HasForeignKey("IDMau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.SanPham", "SanPham")
                        .WithMany("SanPhamct")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.Sale", "Sale")
                        .WithMany("SanPhamCT")
                        .HasForeignKey("IDSale");

                    b.HasOne("AppDaTa.Models.Size", "Size")
                        .WithMany("SanPhamct")
                        .HasForeignKey("IDSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDaTa.Models.TheLoai", "TheLoai")
                        .WithMany("SanPhamct")
                        .HasForeignKey("IDTheLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hang");

                    b.Navigation("Mau");

                    b.Navigation("Sale");

                    b.Navigation("SanPham");

                    b.Navigation("Size");

                    b.Navigation("TheLoai");
                });

            modelBuilder.Entity("AppDaTa.Models.ChucVu", b =>
                {
                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("AppDaTa.Models.GioHang", b =>
                {
                    b.Navigation("GioHangcts");
                });

            modelBuilder.Entity("AppDaTa.Models.HangSX", b =>
                {
                    b.Navigation("SanPhamCT");
                });

            modelBuilder.Entity("AppDaTa.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonCTs");
                });

            modelBuilder.Entity("AppDaTa.Models.MauSac", b =>
                {
                    b.Navigation("SanPhamct");
                });

            modelBuilder.Entity("AppDaTa.Models.NguoiDung", b =>
                {
                    b.Navigation("BinhLuans");

                    b.Navigation("GioHangs");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("AppDaTa.Models.Sale", b =>
                {
                    b.Navigation("SanPhamCT");
                });

            modelBuilder.Entity("AppDaTa.Models.SanPham", b =>
                {
                    b.Navigation("SanPhamct");
                });

            modelBuilder.Entity("AppDaTa.Models.SanPhamChiTiet", b =>
                {
                    b.Navigation("BinhLuans");

                    b.Navigation("GioHangCT");

                    b.Navigation("HoaDonCT");
                });

            modelBuilder.Entity("AppDaTa.Models.Size", b =>
                {
                    b.Navigation("SanPhamct");
                });

            modelBuilder.Entity("AppDaTa.Models.TheLoai", b =>
                {
                    b.Navigation("SanPhamct");
                });

            modelBuilder.Entity("AppDaTa.Models.Voucher", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}