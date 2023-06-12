using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.ViewModels
{
    public class BinhLuanViewModels

    {
        public Guid IdBinhLuan { get; set; }
        public Guid IdSanCt { get; set; }
        public Guid IdNguoiDung { get; set; }
        public DateTime NgayBinhLuan { get; set; }
        public string NoiDung { get; set; }

    }
}
