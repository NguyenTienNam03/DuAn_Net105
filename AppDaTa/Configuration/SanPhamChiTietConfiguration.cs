using AppDaTa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Configuration
{
    public class SanPhamChiTietConfiguration : IEntityTypeConfiguration<SanPhamChiTiet>
    {
        public void Configure(EntityTypeBuilder<SanPhamChiTiet> builder)
        {
            builder.ToTable(nameof(SanPhamChiTiet));
            builder.HasKey(c => c.IDSPCT);
            builder.Property(c => c.GiaBan).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.GiaSale).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(c => c.Anh).HasColumnType("varchar(1000)").IsRequired();
            builder.Property(c => c.MoTa).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int").IsRequired();

            //Khoa ngoai
            builder.HasOne(c => c.Mau).WithMany(c => c.SanPhamct).HasForeignKey(c => c.IDMau);
            builder.HasOne(c => c.Size).WithMany(c => c.SanPhamct).HasForeignKey(c => c.IDSize);
            builder.HasOne(c => c.SanPham).WithMany(c => c.SanPhamct).HasForeignKey(c => c.IDSP);
            builder.HasOne(c => c.Hang).WithMany(c => c.SanPhamCT).HasForeignKey(c => c.IDHang);
            builder.HasOne(c => c.Sale).WithMany(c => c.SanPhamCT).HasForeignKey(c => c.IDSale);
            builder.HasOne(c => c.TheLoai).WithMany(c => c.SanPhamct).HasForeignKey(c => c.IDTheLoai);
        }
    }
}
