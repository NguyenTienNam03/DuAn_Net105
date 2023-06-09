using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class SanPhamChiTiet
    {
        public Guid IDSPCT { get; set; }
        public Guid IDSP { get; set; }
        public Guid IDMau { get; set; }
        public Guid IDSize { get; set; }
        public Guid? IDSale { get; set; } 
        public Guid IDHang { get; set; }
        public Guid IDTheLoai { get; set; }
        public decimal GiaBan { get; set; } 
        public decimal GiaSale { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        //Nhan hoa ngoai cua cac bang SP, Mau , Size , HangSX , TheLoai
        public virtual SanPham SanPham { get; set; }
        public virtual MauSac Mau { get; set; }
        public virtual Size Size { get; set; }
        public virtual HangSX Hang { get; set; }
        public virtual TheLoai TheLoai { get; set; }
        public virtual Sale Sale { get; set; }

        // cho khoa ngoai cua hoadonct va gio hang chi tiet
        public virtual IEnumerable<HoaDonChiTiet> HoaDonCT { get; set; }
        public virtual IEnumerable<BinhLuan> BinhLuans { get; set; }
        public virtual IEnumerable<GioHangChiTiet> GioHangCT { get; set; }
    }
}
