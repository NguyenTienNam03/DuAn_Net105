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
    public class GioHangConfigurations : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable(nameof(GioHang));
            builder.HasKey(c => c.IDGioHang);

            builder.HasOne(c => c.NguoiDung).WithMany(c => c.GioHangs).HasForeignKey(c => c.IDGioHang);
        }
    }
}
