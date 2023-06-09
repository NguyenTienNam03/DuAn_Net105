using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private IAllRepositories<Size> ireposize;
        private QLBG_Context _context = new QLBG_Context();
        public SizeController()
        {
            AllRepositories<Size> repossize = new AllRepositories<Size>(_context, _context.sizes);
            ireposize = repossize;
        }

        // GET: api/<SizeController>
        [HttpGet("[action]")]
        public IEnumerable<Size> GetAll()
        {
            return ireposize.GetAll();
        }

        // GET api/<SizeController>/5
        [HttpGet("{id}")]
        public Size GetById(Guid id)
        {
            return ireposize.GetAll().First(c => c.IDSize == id);
        }

        // POST api/<SizeController>
        [HttpPost("{Create-size}")]
        public bool CreateSize(decimal sizegiay)
        {
            Size size = new Size();
            size.IDSize = Guid.NewGuid();
            size.SizeGiay = sizegiay;
            return ireposize.CreateNewItem(size);
        }

        // PUT api/<SizeController>/5
        [HttpPut("{Edit-size}")]
        public bool UpdateSize(Guid id, decimal sizegiay)
        {
            Size size = ireposize.GetAll().First(c => c.IDSize == id);
            size.SizeGiay += sizegiay;
            return ireposize.UpdateItem(size);
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("{delete-size}")]
        public bool DeleteSize(Guid id)
        {
            Size size = ireposize.GetAll().First(c => c.IDSize == id);
            return ireposize.DeleteItem(size);
        }
    }
}
