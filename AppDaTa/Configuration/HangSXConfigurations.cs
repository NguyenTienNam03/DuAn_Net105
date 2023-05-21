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
    public class HangSXConfigurations : IEntityTypeConfiguration<HangSX>
    {
        public void Configure(EntityTypeBuilder<HangSX> builder)
        {
            builder.ToTable(nameof(HangSX));
            builder.HasKey(c => c.IDHangSx);
            builder.Property(c => c.TenHangSX).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
