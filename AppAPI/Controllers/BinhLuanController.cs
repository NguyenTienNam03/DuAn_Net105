
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private IAllRepositories<BinhLuan> irepos;
        private IAllRepositories<NguoiDung> ireposuser;
        private IAllRepositories<SanPhamChiTiet> ireposspct;
        private QLBG_Context context = new QLBG_Context();
        public BinhLuanController()
        {
            AllRepositories<BinhLuan> repos = new AllRepositories<BinhLuan>(context, context.binhLuans);
            AllRepositories<NguoiDung> reposuser =
                new AllRepositories<NguoiDung>(context, context.nguoiDungs);
            AllRepositories<SanPhamChiTiet> reposspct =
              new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);
            irepos = repos;
            ireposuser = reposuser;
            ireposspct = reposspct;
        }
        // GET: api/<BinhLuan>
        [HttpGet]
        public IEnumerable<BinhLuan> Get()
        {
           return irepos.GetAll();
        }

        // GET api/<BinhLuan>/5
        [HttpGet("{id}")]
        public BinhLuan Get(Guid id)
        {
            return irepos.GetAll().First(p => p.IDBinhLuan == id);
        }

        // POST api/<BinhLuan>
        [HttpPost("create-binhluan")]
        public bool CreateBL(  Guid IDuser, Guid Idspct,string noidung,DateTime nbl)
        {
            BinhLuan BL = new BinhLuan();
            BL.NoiDung = noidung;
            BL.NgayBinh = nbl;
            BL.IDBinhLuan= Guid.NewGuid();
            BL.IDNguoiDung = ireposuser.GetAll().First(c => c.IDUser == IDuser).IDUser;
            BL.IDSPCT = ireposspct.GetAll().First(c => c.IDSPCT == Idspct).IDSPCT;

            return irepos.CreateNewItem(BL);
        }
        [HttpPut]
        [Route("edit-binhluan")]
        public bool UpdateColor(Guid id, string noidung )
        {
            // Trỏ đến màu sắc trong db để sửa
            
            BinhLuan BL = irepos.GetAll().First(p => p.IDBinhLuan == id);
            BL.NoiDung = noidung;
            BL.IDBinhLuan = Guid.NewGuid();
            BL.IDNguoiDung = ireposuser.GetAll().First(c => c.IDUser == IDuser).IDUser;
            BL.IDSPCT = ireposspct.GetAll().First(c => c.IDSPCT == Idspct).IDSPCT;


            return irepos.UpdateItem(BL);
        }
        [HttpDelete("{id}")]
        public bool DeleteBL(Guid id)
        {
            // Trỏ đến màu sắc trong db để sửa
            BinhLuan BL = irepos.GetAll().First(p => p.IDBinhLuan == id);
            return irepos.DeleteItem(BL);
        }

    }
}
