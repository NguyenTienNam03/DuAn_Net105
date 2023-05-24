using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private IAllRepositories<ChucVu> ireposchucvu;
        private QLBG_Context _context = new QLBG_Context();
        public ChucVuController()
        {
            AllRepositories<ChucVu> resposchucvu = new AllRepositories<ChucVu>(_context , _context.chucVus);
            ireposchucvu = resposchucvu;
        }
        // GET: api/<ChucVuContoller>
        [HttpGet]
        public IEnumerable<ChucVu> GetAllChucVu()
        {
            return ireposchucvu.GetAll();
        }

        // GET api/<ChucVuContoller>/5
        [HttpGet("{id}")]
        public ChucVu GetByID(Guid id)
        {
            return ireposchucvu.GetAll().First(c => c.IDRole == id);
        }

        // POST api/<ChucVuContoller>
        [HttpPost("Create-chucvu")]
        public bool CreateChucVu( string tencv , string mota , int trangthai)
        {
            ChucVu cvs = new ChucVu();
            cvs.IDRole = Guid.NewGuid();
            cvs.TenChucVu = tencv;
            cvs.MoTa = mota;
            cvs.TrangThai = trangthai;
            return ireposchucvu.CreateNewItem(cvs);
        }

        // PUT api/<ChucVuContoller>/5
        [HttpPut("Update-chucvu")]
        public bool UpdateChucVu(Guid ID, string tencv, string mota, int trangthai)
        {
            ChucVu vcs = ireposchucvu.GetAll().First(c => c.IDRole==ID);
            vcs.TenChucVu= tencv;
            vcs.MoTa = mota;
            vcs.TrangThai = trangthai;
            return ireposchucvu.UpdateItem(vcs);
        }

        // DELETE api/<ChucVuContoller>/5
        [HttpDelete("Delete-Chucvu")]
        public bool Delete(Guid id)
        {
            ChucVu chucVu = ireposchucvu.GetAll().First(c => c.IDRole == id);
            return ireposchucvu.DeleteItem(chucVu);
        }
    }
}
