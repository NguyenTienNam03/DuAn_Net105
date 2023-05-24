using Microsoft.AspNetCore.Mvc;
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : Controller
    {
        private IAllRepositories<SanPham> irepos;
        private QLBG_Context context = new QLBG_Context();

        public SanPhamController()
        {
            AllRepositories<SanPham> repos = new AllRepositories<SanPham>(context, context.sanPhams);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<SanPham> GetSanPhams()
        {
            return irepos.GetAll();
        }
        [HttpGet("{id}")]
        public SanPham GetSanPhams(Guid id)
        {
            return irepos.GetAll().First(p => p.IdSP == id);
        }
        [HttpPost("Create-SanPham")]
        public bool CreateSanPham(string ten)
        {
            SanPham sanPham = new SanPham();
            sanPham.TenSP = ten;
            sanPham.IdSP = Guid.NewGuid();
            return irepos.CreateNewItem(sanPham);
        }
        [HttpPut]
        [Route("edit-SanPham")]
        public bool UpdateSanPham(Guid id, string ten)
        {
            SanPham sanPham = irepos.GetAll().First(p => p.IdSP == id);
            sanPham.TenSP = ten;
            return irepos.UpdateItem(sanPham);
        }
        [HttpDelete("{id}")]
        public bool DeleteSanPham(Guid id)
        {
            SanPham sanPham = irepos.GetAll().First(p => p.IdSP == id);
            return irepos.DeleteItem(sanPham);
        }
    }

}
