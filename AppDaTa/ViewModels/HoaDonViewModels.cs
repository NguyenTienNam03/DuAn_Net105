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
        public SanPhamChiTietViewModels sanPhamChiTietViewModels { get; set; }
        public HoaDon HoaDon { get; set; }
        public HoaDonChiTiet HoaDonChiTiet { get; set; }
    }
}
