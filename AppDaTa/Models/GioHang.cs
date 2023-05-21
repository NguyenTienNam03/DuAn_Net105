using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class GioHang
    {
        public Guid IDGioHang { get; set; }
        public string Description { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }

        public virtual IEnumerable<GioHangChiTiet> GioHangcts { get; set; }
    }
}
