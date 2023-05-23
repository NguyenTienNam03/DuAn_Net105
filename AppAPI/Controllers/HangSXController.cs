using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangSXController : ControllerBase
    {
        private IAllRepositories<HangSX> ireposHangSX;
        private QLBG_Context context = new QLBG_Context();
        public HangSXController()
        {
                AllRepositories<HangSX> reposHangSX = new AllRepositories<HangSX>(context, context.hangSXs);
                ireposHangSX = reposHangSX;
        }
        // GET: api/<HangSXController>
        [HttpGet]
        public IEnumerable<HangSX> Get()
        {
            return ireposHangSX.GetAll();
        }

        // GET api/<HangSXController>/5
        [HttpGet("{id}")]
        public HangSX Get(Guid id)
        {
            return ireposHangSX.GetAll().First(h => h.IDHangSx == id);
        }

        // POST api/<HangSXController>
        [HttpPost("create-HangSX")]
        public bool CreateHangSX(string tenHangSX)
        {
            HangSX H = new  HangSX();
            H.IDHangSx = Guid.NewGuid();
            H.TenHangSX = tenHangSX;
            return ireposHangSX.CreateNewItem(H);
        }
        [HttpPut]
        [Route("edit-hangSX")]
        public bool UpdateHangSX(Guid id, string tenHangSx)
        {
            HangSX H = ireposHangSX.GetAll().First(p => p.IDHangSx == id);
            H.IDHangSx = Guid.NewGuid();
            H.TenHangSX = tenHangSx;
            return ireposHangSX.UpdateItem(H);
        }
        [HttpDelete("{id}")]
        public bool DeleteHangSX(Guid id)
        {
            HangSX H = ireposHangSX.GetAll().First(p => p.IDHangSx == id);
            return ireposHangSX.DeleteItem(H);
        }
    }
}
