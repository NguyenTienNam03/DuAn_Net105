
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
        private QLBG_Context context = new QLBG_Context();
        public BinhLuanController()
        {
            AllRepositories<BinhLuan> repos =
            new AllRepositories<BinhLuan>(context, context.binhLuans);
            irepos = repos;
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
        [HttpPost("create-mausac")]
        public bool CreateBL(string noidung)
        {
            BinhLuan BL = new BinhLuan();
            BL.NoiDung = noidung;
            BL.IDBinhLuan= Guid.NewGuid();
            //BL.Idspct= Guid.NewGuid();
            //BL.IdnguoiDung= Guid.NewGuid();
          
            return irepos.CreateNewItem(BL);
        }
        [HttpPut]
        [Route("edit-mausac")]
        public bool UpdateColor(Guid id, string noidung )
        {
            // Trỏ đến màu sắc trong db để sửa
            
            BinhLuan BL = irepos.GetAll().First(p => p.IDBinhLuan == id);
            BL.NoiDung = noidung;
            BL.IDBinhLuan = Guid.NewGuid();
            //BL.Idspct = Guid.NewGuid();
            //BL.IdnguoiDung = Guid.NewGuid();
           
            return irepos.UpdateItem(BL);
        }
        [HttpDelete("{id}")]
        public bool DeleteColor(Guid id)
        {
            // Trỏ đến màu sắc trong db để sửa
            BinhLuan BL = irepos.GetAll().First(p => p.IDBinhLuan == id);
            return irepos.DeleteItem(BL);
        }

    }
}
