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
    public class MauSacConfigurations : IEntityTypeConfiguration<MauSac>
    {
        public void Configure(EntityTypeBuilder<MauSac> builder)
        {
            builder.ToTable(nameof(MauSac));
            builder.HasKey(c => c.IDMau);
            builder.Property(c => c.Mausac).HasColumnType("nvarchar(30)").IsRequired();
        }
    }
}
