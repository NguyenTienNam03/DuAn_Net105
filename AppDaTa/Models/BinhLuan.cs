using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class BinhLuan
    {
        public Guid IDBinhLuan { get; set; }
        public Guid IDSPCT { get; set; }
        public Guid IDNguoiDung { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayBinh { get; set; }

        public virtual SanPhamChiTiet SanPhamCT { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
