using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Models
{
    public class ChucVu
    {
        public Guid IDRole { get; set; }
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        public virtual IEnumerable<NguoiDung> NguoiDung { get; set; }
    }
}
