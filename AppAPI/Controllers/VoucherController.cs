using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : Controller
    {
        private IAllRepositories<Voucher> _repos;
        private QLBG_Context _context;
        public VoucherController()
        {
            AllRepositories<Voucher> repos = new AllRepositories<Voucher>(_context, _context.voucher);
            _repos = repos;
        }
        [HttpGet]
        public IEnumerable<Voucher> GettAllVoucher()
        {
            return _repos.GetAll();
        }
        [HttpPost("Create-Voucher")]
        public bool CreateVoucher(Voucher a)
        {
            return _repos.CreateNewItem(a);
        }
        [HttpDelete("{id}")]
        public bool DeleteVoucher(Guid Id)
        {
            Voucher b = _repos.GetAll().First(p => p.IDVoucher == Id);
            
            return _repos.DeleteItem(b);
        }
        [HttpPut("Update-Voucher")]
        public  bool UpdateVoucher(Voucher a)
        {
            Voucher b = _repos.GetAll().First(p => p.IDVoucher == a.IDVoucher);
            b = a;
            return _repos.UpdateItem(b);
        }
    }
}
