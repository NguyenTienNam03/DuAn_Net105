using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public  class HoaDon
    {
        public Guid IdBill { get; set; }
        public Guid IDKhachHang { get; set; }
        public Guid IDVoucher { get; set; }
        public string MaHD { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayShip { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDTNguoiNhan { get; set; }
        public string DiaChiNguoiNhan { get; set; }
        public int TrangThai { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual Voucher Voucher { get; set; }

        public virtual IEnumerable<HoaDonChiTiet> HoaDonCTs { get; set; }
    }
}
