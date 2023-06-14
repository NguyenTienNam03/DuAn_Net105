using AppDaTa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.ViewModels
{
    public class SanPhamChiTietViewModels
    {
        public Guid Id { get; set; }
        public string TenSanPham { get; set; }
        public string MauSac { get ; set; }
        public decimal Size { get; set; }
        public int GiaTriSale { get; set; }
        public string HangGiay { get; set; }
        public string TheLoai { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaSale { get; set; }
        public int Soluong { get;set; }
        public string Anh { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public GioHangChiTiet GioHangChiTiet { get; set; }
    }
}
