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
    public class GioHangChiTietConfigurations : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable(nameof(GioHangChiTiet));

            builder.HasKey(c => c.IDGHCT);
            builder.Property(c => c.Gia).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.SoLuong).HasColumnType("int").IsRequired();

            builder.HasOne(c => c.SanPhamCT).WithMany(c => c.GioHangCT).HasForeignKey(c => c.IDSPCT);
            builder.HasOne(c => c.GioHang).WithMany(c => c.GioHangcts).HasForeignKey(c => c.IDGH);
        }
    }
}
