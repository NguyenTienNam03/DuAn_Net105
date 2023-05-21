using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class HangSX
    {
        public Guid IDHangSx { get; set; }
        public string TenHangSX { get; set; }

        public virtual IEnumerable<SanPhamChiTiet> SanPhamCT { get; set; }
    }
}
