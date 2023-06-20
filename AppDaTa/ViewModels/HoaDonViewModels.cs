using AppDaTa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.ViewModels
{
    public class HoaDonViewModels
    {
		public Guid IdBill { get; set; }
		public string  NameKhachHang { get; set; }
		public decimal GiatriVH { get; set; }
		public string MaHD { get; set; }
		public int SoLuong { get; set; }
		public decimal ThanhTien { get; set; }
		public decimal TongThanhToan { get; set; }
		public DateTime NgayTao { get; set; }
		public DateTime NgayNhan { get; set; }
		public DateTime NgayShip { get; set; }
		public string TenNguoiNhan { get; set; }
		public string SDTNguoiNhan { get; set; }
		public string DiaChiNguoiNhan { get; set; }
		public int TrangThai { get; set; }

	}
}
