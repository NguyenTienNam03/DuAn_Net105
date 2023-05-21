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
    public class TheLoaiConfigurations : IEntityTypeConfiguration<TheLoai>
    {
        public void Configure(EntityTypeBuilder<TheLoai> builder)
        {
            builder.ToTable(nameof(TheLoai));
            builder.HasKey(c => c.IDTheLoai);
            builder.Property(c => c.TenTheLoai).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(c => c.MoTa).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
