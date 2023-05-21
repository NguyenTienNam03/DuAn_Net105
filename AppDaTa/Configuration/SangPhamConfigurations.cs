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
    public class SangPhamConfigurations : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable(nameof(SanPham));
            builder.HasKey(c => c.IdSP);
            builder.Property(c => c.TenSP).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
