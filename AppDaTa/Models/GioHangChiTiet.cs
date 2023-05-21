using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class GioHangChiTiet
    {
        public Guid IDGHCT { get; set; }
        public Guid IDGH { get; set; }
        public Guid IDSPCT { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }

        public virtual GioHang GioHang { get; set; }
        public virtual SanPhamChiTiet SanPhamCT { get; set; }
    }
}
