using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonCTController : Controller
    {
        private IAllRepositories<HoaDonChiTiet> ireposhdct;
        private IAllRepositories<HoaDon> ireposhd;
        private IAllRepositories<SanPhamChiTiet> ireposspct;
        private QLBG_Context context = new QLBG_Context();

        public HoaDonCTController()
        {
            AllRepositories<HoaDonChiTiet> reposhdct = new AllRepositories<HoaDonChiTiet>(context, context.hoaDoncts);
            AllRepositories<HoaDon> reposhd = new AllRepositories<HoaDon>(context, context.hoaDons);
            AllRepositories<SanPhamChiTiet> reposspct = new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);

            ireposhdct = reposhdct;
            ireposhd = reposhd;
            ireposspct = reposspct;
        }
        [HttpGet]
        public IEnumerable<HoaDonChiTiet> GetHoaDonChiTiets()
        {
            return ireposhdct.GetAll();
        }
        [HttpGet("{id}")]
        public HoaDonChiTiet GetHoaDonChiTiets(Guid id)
        {
            return ireposhdct.GetAll().First(p => p.IDHDCT == id);
        }

        [HttpPost("Create-HoaDonCT")]

        public bool CreateHDCT(Guid idhd, Guid idspct, decimal gia, int sl)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.IDHDCT = Guid.NewGuid();
            hdct.IDHD = ireposhd.GetAll().First(p => p.IdBill == idhd).IdBill;
            hdct.IDSPCT = ireposspct.GetAll().First(p => p.IDSPCT == idspct).IDSPCT;
            hdct.Gia = gia;
            hdct.SoLuong = sl;

            return ireposhdct.CreateNewItem(hdct);

        }
        [HttpPut("Update-HoaDonCT")]

        public bool UpdateHDCT(Guid idhct, Guid idhd, Guid idspct, decimal gia, int sl)
        {
            HoaDonChiTiet hdct = ireposhdct.GetAll().FirstOrDefault(p => p.IDHDCT == idhct);
            hdct.IDHD = ireposhd.GetAll().First(p => p.IdBill == idhd).IdBill;
            hdct.IDSPCT = ireposspct.GetAll().First(p => p.IDSPCT == idspct).IDSPCT;
            hdct.Gia = gia;
            hdct.SoLuong = sl;
            return ireposhdct.UpdateItem(hdct);

        }

        [HttpDelete("Delete-HoaDonCT")]
        public bool DeleteHDCT(Guid idhct)
        {
            HoaDonChiTiet hdct = ireposhdct.GetAll().FirstOrDefault(p => p.IDHDCT == idhct);
            return ireposhdct.DeleteItem(hdct);
        }

    }
}
