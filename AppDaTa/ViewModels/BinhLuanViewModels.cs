using AppDaTa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.ViewModels
{
    public class BinhLuanViewModels

    {
        public SanPhamChiTietViewModels sanPhamChiTietViewModels { get; set; }
		public List<BinhLuan> binhLuans { get; set; }
        public List<NguoiDung> nguoiDung { get; set; }

    }
}
