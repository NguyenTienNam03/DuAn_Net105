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
    public class VoucherConfigurations : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable(nameof(Voucher));
            builder.HasKey(c => c.IDVoucher);
            builder.Property(c => c.MaVoucher).HasColumnType("varchar(10)").IsRequired();
            builder.Property(c => c.NgayTao).HasColumnType("DateTime").IsRequired();
            builder.Property(c => c.Dieukien).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.NgayBatDau).HasColumnType("DateTime").IsRequired();
            builder.Property(c => c.NgayKetThuc).HasColumnType("DateTime").IsRequired();
            builder.Property(c => c.GiaTriVoucher).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.Soluong).HasColumnType("int").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}
