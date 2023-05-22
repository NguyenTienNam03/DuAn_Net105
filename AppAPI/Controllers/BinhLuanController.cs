using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private IAllRepositories<BinhLuan> irepos;
        private Du_An_NET105Context context= new Du_An_NET105Context();
        public BinhLuanController()
        {
            AllRepositories<BinhLuan> repos =
            new AllRepositories<BinhLuan>(context, context.BinhLuans);
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
            return irepos.GetAll().First(p => p.IdbinhLuan == id);
        }

        // POST api/<BinhLuan>
        [HttpPost("create-mausac")]
        public bool CreateBL(string noidung)
        {
            BinhLuan BL = new BinhLuan();
            BL.NoiDung = noidung;
            BL.IdbinhLuan= Guid.NewGuid();
            BL.Idspct= Guid.NewGuid();
            BL.IdnguoiDung= Guid.NewGuid();
          
            return irepos.CreateItem(BL);
        }
        [HttpPut]
        [Route("edit-mausac")]
        public bool UpdateColor(Guid id, string noidung )
        {
            // Trỏ đến màu sắc trong db để sửa
            
            BinhLuan BL = irepos.GetAll().First(p => p.IdbinhLuan == id);
            BL.NoiDung = noidung;
            BL.IdbinhLuan = Guid.NewGuid();
            BL.Idspct = Guid.NewGuid();
            BL.IdnguoiDung = Guid.NewGuid();
           
            return irepos.UpdateItem(BL);
        }
        [HttpDelete("{id}")]
        public bool DeleteColor(Guid id)
        {
            // Trỏ đến màu sắc trong db để sửa
            BinhLuan BL = irepos.GetAll().First(p => p.IdbinhLuan == id);
            return irepos.DeleteItem(BL);
        }

    }
}
