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
        private IAllRepositories<HangSX> irepos;
        private QLBG_Context context = new QLBG_Context();
        public HangSXController()
        {
                AllRepositories<HangSX> repos = new AllRepositories<HangSX>(context, context.hangSXs);
                irepos = repos;
        }
        // GET: api/<HangSXController>
        [HttpGet]
        public IEnumerable<HangSX> Get()
        {
            return irepos.GetAll();
        }

        // GET api/<HangSXController>/5
        [HttpGet("{id}")]
        public HangSX Get(Guid id)
        {
            return irepos.GetAll().First(p => p.IDHangSx == id);
        }

        // POST api/<HangSXController>
        [HttpPost("create-HangSX")]
        public bool CreateHangSX(string tenHangSX)
        {
            HangSX H = new  HangSX();
            H.TenHangSX = tenHangSX;
            H.IDHangSx = Guid.NewGuid();
            return irepos.CreateNewItem(H);
        }

    }
}
