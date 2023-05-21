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
    public class NguoiDungConfigurations : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.ToTable("NguoiDung");
            builder.HasKey(c => c.IDUser);
            builder.Property(c => c.TenKhachHang).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(c => c.SDT).HasColumnType("varchar(10)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.MatKhau).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.DiaChi).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int").IsRequired();

            builder.HasOne(c => c.ChucVu).WithMany(c => c.NguoiDung).HasForeignKey(c => c.IDRole);
        }
    }
}
