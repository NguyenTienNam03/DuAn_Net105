USE [DuAn_Net105]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[IDBinhLuan] [uniqueidentifier] NOT NULL,
	[IDSPCT] [uniqueidentifier] NOT NULL,
	[IDNguoiDung] [uniqueidentifier] NOT NULL,
	[NoiDung] [nvarchar](1000) NOT NULL,
	[NgayBinh] [datetime] NOT NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[IDBinhLuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[IDRole] [uniqueidentifier] NOT NULL,
	[TenChucVu] [nvarchar](25) NOT NULL,
	[MoTa] [nvarchar](100) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[IDRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IDGioHang] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IDGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHangChiTiet]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHangChiTiet](
	[IDGHCT] [uniqueidentifier] NOT NULL,
	[IDGH] [uniqueidentifier] NOT NULL,
	[IDSPCT] [uniqueidentifier] NOT NULL,
	[Gia] [decimal](18, 0) NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_GioHangChiTiet] PRIMARY KEY CLUSTERED 
(
	[IDGHCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangSX]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangSX](
	[IDHangSx] [uniqueidentifier] NOT NULL,
	[TenHangSX] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_HangSX] PRIMARY KEY CLUSTERED 
(
	[IDHangSx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IdBill] [uniqueidentifier] NOT NULL,
	[IDKhachHang] [uniqueidentifier] NOT NULL,
	[IDVoucher] [uniqueidentifier] NOT NULL,
	[MaHD] [varchar](15) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Gia] [decimal](18, 0) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[NgayNhan] [datetime] NOT NULL,
	[NgayShip] [datetime] NOT NULL,
	[TenNguoiNhan] [nvarchar](50) NOT NULL,
	[SDTNguoiNhan] [varchar](10) NOT NULL,
	[DiaChiNguoiNhan] [nvarchar](1000) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[IdBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonCT]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonCT](
	[IDHDCT] [uniqueidentifier] NOT NULL,
	[IDHD] [uniqueidentifier] NOT NULL,
	[IDSPCT] [uniqueidentifier] NOT NULL,
	[Gia] [decimal](18, 0) NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonCT] PRIMARY KEY CLUSTERED 
(
	[IDHDCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSac]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MauSac](
	[IDMau] [uniqueidentifier] NOT NULL,
	[Mausac] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_MauSac] PRIMARY KEY CLUSTERED 
(
	[IDMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IDUser] [uniqueidentifier] NOT NULL,
	[IDRole] [uniqueidentifier] NOT NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[SDT] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[MatKhau] [varchar](20) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[IDUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[IDSale] [uniqueidentifier] NOT NULL,
	[MaSale] [varchar](10) NOT NULL,
	[NgayBatDau] [datetime] NOT NULL,
	[NgayKetThuc] [datetime] NOT NULL,
	[GiaTriSale] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[IDSale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IdSP] [uniqueidentifier] NOT NULL,
	[TenSP] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IdSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhamChiTiet]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamChiTiet](
	[IDSPCT] [uniqueidentifier] NOT NULL,
	[IDSP] [uniqueidentifier] NOT NULL,
	[IDMau] [uniqueidentifier] NOT NULL,
	[IDSize] [uniqueidentifier] NOT NULL,
	[IDSale] [uniqueidentifier] NOT NULL,
	[IDHang] [uniqueidentifier] NOT NULL,
	[IDTheLoai] [uniqueidentifier] NOT NULL,
	[GiaBan] [decimal](18, 0) NOT NULL,
	[GiaSale] [decimal](18, 0) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Anh] [varchar](1000) NOT NULL,
	[MoTa] [nvarchar](1000) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_SanPhamChiTiet] PRIMARY KEY CLUSTERED 
(
	[IDSPCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[IDSize] [uniqueidentifier] NOT NULL,
	[SizeGiay] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[IDSize] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[IDTheLoai] [uniqueidentifier] NOT NULL,
	[TenTheLoai] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[IDTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 21/05/2023 23:16:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[IDVoucher] [uniqueidentifier] NOT NULL,
	[MaVoucher] [varchar](10) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[Dieukien] [decimal](18, 0) NOT NULL,
	[NgayBatDau] [datetime] NOT NULL,
	[NgayKetThuc] [datetime] NOT NULL,
	[GiaTriVoucher] [decimal](18, 0) NOT NULL,
	[Soluong] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[IDVoucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_NguoiDung_IDNguoiDung] FOREIGN KEY([IDNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IDUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_NguoiDung_IDNguoiDung]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_SanPhamChiTiet_IDSPCT] FOREIGN KEY([IDSPCT])
REFERENCES [dbo].[SanPhamChiTiet] ([IDSPCT])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_SanPhamChiTiet_IDSPCT]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_NguoiDung_IDGioHang] FOREIGN KEY([IDGioHang])
REFERENCES [dbo].[NguoiDung] ([IDUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_NguoiDung_IDGioHang]
GO
ALTER TABLE [dbo].[GioHangChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_GioHangChiTiet_GioHang_IDGH] FOREIGN KEY([IDGH])
REFERENCES [dbo].[GioHang] ([IDGioHang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GioHangChiTiet] CHECK CONSTRAINT [FK_GioHangChiTiet_GioHang_IDGH]
GO
ALTER TABLE [dbo].[GioHangChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_GioHangChiTiet_SanPhamChiTiet_IDSPCT] FOREIGN KEY([IDSPCT])
REFERENCES [dbo].[SanPhamChiTiet] ([IDSPCT])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GioHangChiTiet] CHECK CONSTRAINT [FK_GioHangChiTiet_SanPhamChiTiet_IDSPCT]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NguoiDung_IDKhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[NguoiDung] ([IDUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NguoiDung_IDKhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Voucher_IDVoucher] FOREIGN KEY([IDVoucher])
REFERENCES [dbo].[Voucher] ([IDVoucher])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Voucher_IDVoucher]
GO
ALTER TABLE [dbo].[HoaDonCT]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonCT_HoaDon_IDHD] FOREIGN KEY([IDHD])
REFERENCES [dbo].[HoaDon] ([IdBill])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonCT] CHECK CONSTRAINT [FK_HoaDonCT_HoaDon_IDHD]
GO
ALTER TABLE [dbo].[HoaDonCT]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonCT_SanPhamChiTiet_IDSPCT] FOREIGN KEY([IDSPCT])
REFERENCES [dbo].[SanPhamChiTiet] ([IDSPCT])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonCT] CHECK CONSTRAINT [FK_HoaDonCT_SanPhamChiTiet_IDSPCT]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_ChucVu_IDRole] FOREIGN KEY([IDRole])
REFERENCES [dbo].[ChucVu] ([IDRole])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_ChucVu_IDRole]
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamChiTiet_HangSX_IDHang] FOREIGN KEY([IDHang])
REFERENCES [dbo].[HangSX] ([IDHangSx])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet] CHECK CONSTRAINT [FK_SanPhamChiTiet_HangSX_IDHang]
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamChiTiet_MauSac_IDMau] FOREIGN KEY([IDMau])
REFERENCES [dbo].[MauSac] ([IDMau])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet] CHECK CONSTRAINT [FK_SanPhamChiTiet_MauSac_IDMau]
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamChiTiet_Sale_IDSale] FOREIGN KEY([IDSale])
REFERENCES [dbo].[Sale] ([IDSale])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet] CHECK CONSTRAINT [FK_SanPhamChiTiet_Sale_IDSale]
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamChiTiet_SanPham_IDSP] FOREIGN KEY([IDSP])
REFERENCES [dbo].[SanPham] ([IdSP])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet] CHECK CONSTRAINT [FK_SanPhamChiTiet_SanPham_IDSP]
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamChiTiet_Size_IDSize] FOREIGN KEY([IDSize])
REFERENCES [dbo].[Size] ([IDSize])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet] CHECK CONSTRAINT [FK_SanPhamChiTiet_Size_IDSize]
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_SanPhamChiTiet_TheLoai_IDTheLoai] FOREIGN KEY([IDTheLoai])
REFERENCES [dbo].[TheLoai] ([IDTheLoai])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet] CHECK CONSTRAINT [FK_SanPhamChiTiet_TheLoai_IDTheLoai]
GO
