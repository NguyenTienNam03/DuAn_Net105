using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class QLBG_Context : DbContext
    {
        public QLBG_Context() { }
        public QLBG_Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<SanPhamChiTiet> sanPhamCTs { get; set; }
        public DbSet<MauSac> maus { get; set; }
        public DbSet<HangSX> hangSXs { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<TheLoai> theLoai { get; set; }
        public DbSet<BinhLuan> binhLuans { get; set; }
        public DbSet<Voucher> voucher { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<GioHangChiTiet> gioHangCTs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonChiTiet> hoaDoncts { get; set; }
        public DbSet<NguoiDung> nguoiDungs { get; set; }
        public DbSet<ChucVu> chucVus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=TRANTRUNGDONG03\SQLEXPRESS01;Initial Catalog=DuAn_Net105;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
