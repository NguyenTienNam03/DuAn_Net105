using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private IAllRepositories<GioHang> ireposgiohang;
        private IAllRepositories<NguoiDung> ireposuser;
        private QLBG_Context _Context = new QLBG_Context();
        public GioHangController() 
        {
            AllRepositories<GioHang> reposgiohang = new AllRepositories<GioHang>(_Context , _Context.gioHangs);
            AllRepositories<NguoiDung> reposuser = new AllRepositories<NguoiDung>(_Context, _Context.nguoiDungs);
            ireposgiohang = reposgiohang;
            ireposuser = reposuser;
        }
        // GET: api/<GioHangController>
        [HttpGet]
        public IEnumerable<GioHang> GetAll()
        {
            return ireposgiohang.GetAll();
        }

        // GET api/<GioHangController>/5
        [HttpGet("{id}")]
        public GioHang Get(Guid id)
        {
            return ireposgiohang.GetAll().First(c => c.IDGioHang == id);
        }

        // POST api/<GioHangController>
        [HttpPost("Create-giohang")]
        public bool CreateGioHang(Guid id, string description)
        {
            GioHang gioHang = new GioHang();
            gioHang.IDGioHang = ireposuser.GetAll().First(c => c.IDUser == id); // lay id nguoi dung dang nhap
            gioHang.Description = description;
            return ireposgiohang.CreateNewItem(gioHang);
        }
    }
}
