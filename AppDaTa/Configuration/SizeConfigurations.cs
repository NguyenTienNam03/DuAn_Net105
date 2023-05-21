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
    public class SizeConfigurations : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable(nameof(Size));
            builder.HasKey(c => c.IDSize);
            builder.Property(c => c.SizeGiay).HasColumnType("decimal").IsRequired();
        }
    }
}
