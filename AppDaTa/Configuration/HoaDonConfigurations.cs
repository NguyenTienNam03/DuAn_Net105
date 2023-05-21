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
    public class HoaDonConfigurations : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(x => x.IdBill);

            builder.Property(x => x.MaHD).HasColumnType("varchar(15)").IsRequired();
            builder.Property(x => x.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(x => x.Gia).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.NgayTao).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.NgayNhan).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.NgayShip).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.TenNguoiNhan).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(c => c.SDTNguoiNhan).HasColumnType("varchar(10)").IsRequired();
            builder.Property(c => c.DiaChiNguoiNhan).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int").IsRequired();

            builder.HasOne(x => x.NguoiDung).WithMany(c => c.HoaDons).HasForeignKey(c => c.IDKhachHang);
            builder.HasOne(c => c.Voucher).WithMany(c => c.HoaDons).HasForeignKey(c => c.IDVoucher);
        }
    }
}
