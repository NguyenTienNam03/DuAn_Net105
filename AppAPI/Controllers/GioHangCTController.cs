using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
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
        public GioHangCTController()
        {
            AllRepositories<GioHangChiTiet> reposGHCT = new AllRepositories<GioHangChiTiet>(context, context.gioHangCTs);
            AllRepositories<GioHang> reposGH = new AllRepositories<GioHang>(context, context.gioHangs);
            AllRepositories<SanPhamChiTiet> reposSPCT = new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);
            ireposGHCT = reposGHCT;
            ireposSPCT = reposSPCT;
            ireposGH = reposGH;
        }
        // GET: api/<GioHangCTController>
        [HttpGet]
        public IEnumerable<GioHangChiTiet> Get()
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
       [HttpPost("create-giohangchitiet")]
        public bool CreateGHCT( Guid idghct, Guid idgh, Guid idspct, decimal gia, int soLuong )
        {
            GioHangChiTiet ghct = new  GioHangChiTiet();
            ghct.IDGHCT = Guid.NewGuid();
            ghct.IDGH = ireposGH.GetAll().First(ghct => ghct.IDGioHang == idgh).IDGioHang;
            ghct.IDSPCT = ireposSPCT.GetAll().First(ghct => ghct.IDSPCT == idspct).IDSPCT;
            ghct.Gia = gia;
            ghct.SoLuong = soLuong;
            return ireposGHCT.CreateNewItem(ghct);
        }
        [HttpPut]
        [Route("edit-giohangchitiet")]
        public bool UpdateGHCT(Guid idghct, Guid idgh, Guid idspct, decimal gia, int soluong)
        {
            GioHangChiTiet ghct = new GioHangChiTiet();
            ghct.IDGHCT = Guid.NewGuid();
            ghct.IDGH = ireposGH.GetAll().First(ghct => ghct.IDGioHang == idgh).IDGioHang;
            ghct.IDSPCT = ireposSPCT.GetAll().First(ghct => ghct.IDSPCT == idspct).IDSPCT;
            ghct.Gia = gia;
            ghct.SoLuong = soluong;
            return ireposGHCT.UpdateItem(ghct);
        }
        [HttpDelete("{id}")]
        public bool DeleteGHCT(Guid id)
        {
            GioHangChiTiet ghct = ireposGHCT.GetAll().First(ghct => ghct.IDGHCT == id);
            return ireposGHCT.DeleteItem(ghct);
        }
        // trân  trung đông
        //sasadasdsadcs

    }
}
