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
    public class HoaDonChiTietConfigurations : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonCT");
            builder.HasKey(c => c.IDHDCT);
            builder.Property(c => c.Gia).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.SoLuong).HasColumnType("int").IsRequired();

            builder.HasOne(c => c.HoaDon).WithMany(c => c.HoaDonCTs).HasForeignKey(c => c.IDHD);
            builder.HasOne(c => c.SanPhamct).WithMany(c => c.HoaDonCT).HasForeignKey(c => c.IDSPCT);
        }
    }
}
