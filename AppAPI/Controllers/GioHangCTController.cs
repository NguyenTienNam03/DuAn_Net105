using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangCTController : ControllerBase
    {
        private IAllRepositories<GioHangChiTiet> ireposGHCT;
        private IAllRepositories<GioHang> ireposGH;
        private IAllRepositories<SanPhamChiTiet> ireposSPCT;
        private QLBG_Context context = new QLBG_Context();
        private List<SanPhamChiTietViewModels> _lstspct;
        public GioHangCTController()
        {
            AllRepositories<GioHangChiTiet> reposGHCT = new AllRepositories<GioHangChiTiet>(context, context.gioHangCTs);
            AllRepositories<GioHang> reposGH = new AllRepositories<GioHang>(context, context.gioHangs);
            AllRepositories<SanPhamChiTiet> reposSPCT = new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);
            ireposGHCT = reposGHCT;
            ireposSPCT = reposSPCT;
            _lstspct = new List<SanPhamChiTietViewModels>();
            ireposGH = reposGH;
        }
        // GET: api/<GioHangCTController>
        [HttpGet("[action]")]
        public IEnumerable<GioHangChiTiet> GetAll()
        {
            return ireposGHCT.GetAll();
        }

        // GET api/<GioHangCTController>/5
        [HttpGet("{id}")]
        public GioHangChiTiet Get(Guid id)
        {
            return ireposGHCT.GetAll().First(ghct => ghct.IDGHCT == id);
        }

        // POST api/<GioHangCTController>
        [HttpPost("{create-giohangchitiet}")]
        public bool ThemVaoGioHang(Guid idgh, Guid idspct)
        {
            if (ireposGHCT.GetAll().Any(c => c.IDSPCT == idspct) == true)
            {
                var idspct1 = ireposSPCT.GetAll().FirstOrDefault(c => c.IDSPCT == idspct).IDSPCT;
                GioHangChiTiet ghct = ireposGHCT.GetAll().First(ghct => ghct.IDSPCT == idspct);
                if (ghct != null)
                {
                    ghct.SoLuong++;
                }
                return ireposGHCT.UpdateItem(ghct);
            }
            else
            {
                GioHangChiTiet ghct = new GioHangChiTiet();
                ghct.IDGHCT = Guid.NewGuid();
                ghct.IDGH = ireposGH.GetAll().First(ghct => ghct.IDGioHang == idgh).IDGioHang;
                ghct.IDSPCT = ireposSPCT.GetAll().First(ghct => ghct.IDSPCT == idspct).IDSPCT;
                ghct.Gia = ireposSPCT.GetAll().First(c => c.IDSPCT == idspct).GiaSale;
                ghct.SoLuong = 1;
                return ireposGHCT.CreateNewItem(ghct);
            }
        }
        [HttpPut("[action]")]
        public bool UpdateGHCT(Guid idspct, int soluong)
        {
            var soluongton = ireposSPCT.GetAll().FirstOrDefault(c => c.IDSPCT == idspct).SoLuong;
            GioHangChiTiet ghct = ireposGHCT.GetAll().FirstOrDefault(ghct => ghct.IDSPCT == idspct);
            if (soluongton > 0 && soluongton <= soluong)
            {
                if (ghct != null)
                {
                    ghct.SoLuong = soluong;
                }
            }
            return ireposGHCT.UpdateItem(ghct);
        }
        [HttpDelete("[action]")]
        public bool DeleteGHCT(Guid id)
        {
            GioHangChiTiet ghct = ireposGHCT.GetAll().First(ghct => ghct.IDGHCT == id);
            return ireposGHCT.DeleteItem(ghct);
        }

    }
}
