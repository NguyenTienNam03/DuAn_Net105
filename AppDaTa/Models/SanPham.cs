using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class SanPham
    {
        public Guid IdSP { get; set; }
        public string TenSP { get; set; }
        public virtual IEnumerable<SanPhamChiTiet> SanPhamct { get; set; }
    }
}
