using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class TheLoai
    {
        public Guid IDTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string MoTa { get; set; }
        public virtual IEnumerable<SanPhamChiTiet> SanPhamct { get; set; }
    }
}
