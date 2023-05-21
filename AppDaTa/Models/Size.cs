using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class Size
    {
        public Guid IDSize { get; set; }
        public decimal SizeGiay { get; set; }
        public virtual IEnumerable<SanPhamChiTiet> SanPhamct { get; set; }
    }
}
