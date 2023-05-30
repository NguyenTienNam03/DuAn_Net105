using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{


    // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacController : ControllerBase
    {
        private IAllRepositories<MauSac> ireposmausac;
        private QLBG_Context _context = new QLBG_Context();
        public MauSacController()
        {
            AllRepositories<MauSac> reposmausac = new AllRepositories<MauSac>(_context, _context.maus);
            ireposmausac = reposmausac;
        }
        [HttpGet]
        public IEnumerable<MauSac> GetAllColor()
        {
            return ireposmausac.GetAll();
        }
        [HttpGet("{id}")]
        public MauSac Get(Guid id)
        {
            return ireposmausac.GetAll().First(c => c.IDMau == id);
        }

        // POST api/<SaleController>
        [HttpPost("create-mausac")]
        public bool CreateMauSac(string mausac)
        {
            MauSac mau = new MauSac();
            mau.IDMau = Guid.NewGuid();
            mau.Mausac = mausac;
            return ireposmausac.CreateNewItem(mau);
        }

        // PUT api/<SaleController>/5
        [HttpPut("Edit-color")]
        public bool UpdateMauSac(Guid id, string ms)
        {
            MauSac color = ireposmausac.GetAll().First(c => c.IDMau == id); 
            color.Mausac = ms;
            return ireposmausac.UpdateItem(color);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("Delete-color")]
        public bool Delete(Guid id)
        {
            MauSac mau = ireposmausac.GetAll().First(c => c.IDMau == id);
            return ireposmausac.DeleteItem(mau);
        }
    }
}