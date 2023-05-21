using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class MauSac
    {
        public Guid IDMau { get; set; }
        public string Mausac { get; set; }
        public virtual IEnumerable<SanPhamChiTiet> SanPhamct { get; set; }
    }
}
