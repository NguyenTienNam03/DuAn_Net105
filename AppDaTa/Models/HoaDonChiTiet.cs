using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class HoaDonChiTiet
    {
        public Guid IDHDCT { get; set; }
        public Guid IDHD { get; set; }
        public Guid IDSPCT { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPhamChiTiet SanPhamct { get; set; }
    }
}
