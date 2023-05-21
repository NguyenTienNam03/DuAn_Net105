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
    public class BinhLuanConfigurations : IEntityTypeConfiguration<BinhLuan>
    {
        public void Configure(EntityTypeBuilder<BinhLuan> builder)
        {
            builder.ToTable("BinhLuan");
            builder.HasKey(c => c.IDBinhLuan);
            builder.Property(c => c.NoiDung).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.NgayBinh).HasColumnType("DateTime").IsRequired();

            builder.HasOne(c => c.NguoiDung).WithMany(c => c.BinhLuans).HasForeignKey(c => c.IDNguoiDung);
            builder.HasOne(c => c.SanPhamCT).WithMany(c => c.BinhLuans).HasForeignKey(c => c.IDSPCT);
        }
    }
}
