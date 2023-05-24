using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuContoller : ControllerBase
    {
        private IAllRepositories<ChucVu> ireposchucvu;
        private QLBG_Context _context = new QLBG_Context();
        public ChucVuContoller()
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
        public bool CreateChucVu(ChucVu cv)
        {
            ChucVu cvs = new ChucVu();
            cvs.IDRole = Guid.NewGuid();
            cvs.TenChucVu = cv.TenChucVu;
            cvs.MoTa = cv.MoTa;
            cvs.TrangThai = cv.TrangThai;
            return ireposchucvu.CreateNewItem(cvs);
        }

        // PUT api/<ChucVuContoller>/5
        [HttpPut("Update-chucvu")]
        public bool UpdateChucVu(Guid id , ChucVu cv)
        {
            ChucVu vcs = ireposchucvu.GetAll().First(c => c.IDRole==id);
            vcs.TenChucVu=cv.TenChucVu;
            vcs.MoTa = cv.MoTa;
            vcs.TrangThai = cv.TrangThai;
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
